using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public class CarRepository : ICarRepository
    {
        public void AddCar(Car car) => CarManagement.Instance.AddCar(car);

        public void RemoveCar(int carid) => CarManagement.Instance.RemoveCar(carid);

        public Car GetCarByID(int carid) => CarManagement.Instance.GetCarByID(carid);

        public IEnumerable<Car> GetCars() => CarManagement.Instance.GetCars(); 

        public void UpdateCar(Car car) => CarManagement.Instance.UpdateCar(car);
    }
}
