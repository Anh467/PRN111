using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
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

namespace Server
{
    /// <summary>
    /// Interaction logic for Mess.xaml
    /// </summary>
    public partial class Mess : Window
    {

        IPEndPoint IP;
        Socket server;
        List<Socket> clients;
        public Mess()
        {
            InitializeComponent();
            Connect();
        }
        void Connect()
        {
            // IP Dia chi cua server
            clients = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Any, 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            server.Bind(IP);

            Thread listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        clients.Add(client);

                        // Sử dụng Dispatcher để thực hiện các công việc trên giao diện người dùng
                        Dispatcher.Invoke(() =>
                        {
                            Thread recieve = new Thread(Recieve);
                            recieve.IsBackground = true;
                            recieve.Start();
                        });

                        
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }

            });
            listen.IsBackground = true;
            listen.Start();
        }

        void Closes()
        {
            server.Close();
        }
        void Send(Socket client)
        {
            if (txbMessage.Text != string.Empty)
            {
                client.Send(Serialize(txbMessage.Text));
               
            }
        }
        void Recieve(object obj)
        {
            Socket client = (Socket)obj;
            try
            {
                byte[] data = new byte[1024 * 5000];
                client.Receive(data);
                string mess = (string)Deserialize(data);
                Add(mess);
            }
            catch
            {
                clients.Remove(client);
                client.Close();
            }
        }
        void Add(string mess)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = mess;
            lvMess.Items.Add(textBlock);
        }
        byte[] Serialize(Object obj)
        {
            MemoryStream stream = new MemoryStream();
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
            if (clients == null)
            {
                MessageBox.Show("No client online");
                return;
            }
            foreach(Socket socket in clients) {
                Send(socket);
            }
            Add(txbMessage.Text);
            txbMessage.Clear();
        }
    }
}
