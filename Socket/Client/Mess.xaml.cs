using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for Mess.xaml
    /// </summary>
    public partial class Mess : Window
    {
        IPEndPoint IP;
        Socket client;

        public Mess()
        {
            InitializeComponent();
            Connect();
        }

        void Connect()
        {
            // IP Dia chi cua server
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                client.Connect(IP);
            }
            catch
            {
                // Sử dụng Dispatcher để hiển thị MessageBox trên luồng chính
                Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("Khong the ket noi den server",
                                    "Loi",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                });
                return;
            }

            // Tiếp tục sử dụng Dispatcher để thực hiện các công việc trên giao diện người dùng
            Dispatcher.Invoke(() =>
            {
                Thread listen = new Thread(Recieve);
                listen.IsBackground = true;
                listen.Start();
            });

            
        }

        void Closes()
        {
            client.Close();
        }
        void Send()
        {
            if (txbMessage.Text != string.Empty)
            {
                client.Send(Serialize(txbMessage.Text));
               
            }

        }
        void Recieve()
        {
            try
            {
                byte[] data = new byte[1024 * 5000];
                client.Receive(data);
                string mess = (string) Deserialize(data);
                Add(mess);
            }catch 
            {
                Closes();
            }
        }
        void Add(string mess)
        {
            TextBlock textBlock= new TextBlock();
            textBlock.Text = mess;
            lvMess.Items.Add(textBlock);
        }
        byte[] Serialize(Object obj)
        {
            MemoryStream stream= new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            return stream.ToArray();
        }
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }

        
        private void Window_Closed(object sender, EventArgs e)
        {
            Closes();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Send();
            Add(txbMessage.Text);
            txbMessage.Clear();
        }
    }
}
