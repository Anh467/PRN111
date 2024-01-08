using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace AutomobileLibrary.DataAccess
{
    public class CarManagement
    {
        private static CarManagement instance;
        private static readonly object instanceLock = new object();
        private CarManagement() { }
        public static CarManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new CarManagement();
                    }
                    return instance;
                }
            }
        }
        //----------------------------------------------
        public IEnumerable<Car> GetCars() {
            List<Car> cars;
            try
            {
                var myStockDb = new MyStockContext();
                cars = myStockDb.Cars.ToList();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cars;
        }
        //----------------------------------------------
        public Car GetCarByID(int carid)
        {
            Car car = null;
            try
            {
                var myStockDb = new MyStockContext();
                car = myStockDb.Cars.SingleOrDefault(p => p.CarId == carid);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return car;
        }
        //----------------------------------------------
        public void AddCar(Car car)
        {
            try
            { 
                var _car = GetCarByID(car.CarId);
                if (_car == null)
                {
                    var myStockDb = new MyStockContext();
                    myStockDb.Cars.Add(car);
                    myStockDb.SaveChanges();
                }
                else
                {
                    throw new Exception("The car is ready exist");
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //----------------------------------------------
        public void UpdateCar(Car car)
        {
            try
            {

                var _car = GetCarByID(car.CarId);
                if (_car != null)
                {
                    var myStockDb = new MyStockContext();
                    myStockDb.Entry<Car>(car).State= EntityState.Modified;
                    myStockDb.SaveChanges();
                }
                else
                {
                    throw new Exception("The car is not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //----------------------------------------------
        public void RemoveCar(int carid)
        {
            try
            {

                var _car = GetCarByID(carid);
                if (_car != null)
                {
                    var myStockDb = new MyStockContext();
                    myStockDb.Cars.Remove(_car);
                    myStockDb.SaveChanges();
                }
                else
                {
                    throw new Exception("The car is not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //----------------------------------------------
    }
}
