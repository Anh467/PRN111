using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibrary.DataAccess;
namespace AutomobileLibrary.Repository
{
    public interface ICarRepository
    {
        public IEnumerable<Car> GetCars();
        public Car GetCarByID(int carid);
        public void RemoveCar(int carid); 
        public void UpdateCar(Car car);
        public void AddCar(Car car);
    }
}
