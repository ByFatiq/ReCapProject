using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{CarId=1,BrandId=1,ColorId=1,ModelYear=2018,DailyPrice=500000,CarDescription="Audi"},
                new Car{CarId=2,BrandId=1,ColorId=1,ModelYear=2015,DailyPrice=400000,CarDescription="Audi"},
                new Car{CarId=3,BrandId=2,ColorId=1,ModelYear=2010,DailyPrice=100000,CarDescription="Opel"},
                new Car{CarId=4,BrandId=2,ColorId=1,ModelYear=2009,DailyPrice=95000,CarDescription="Opel"},
                new Car{CarId=5,BrandId=3,ColorId=1,ModelYear=2000,DailyPrice=50000,CarDescription="Fiat"},
                new Car{CarId=6,BrandId=4,ColorId=1,ModelYear=2020,DailyPrice=1000000,CarDescription="BMW"},
                new Car{CarId=7,BrandId=4,ColorId=1,ModelYear=2007,DailyPrice=100000,CarDescription="BMW"},
                new Car{CarId=8,BrandId=3,ColorId=1,ModelYear=2012,DailyPrice=120000,CarDescription="Fiat"},
            };
        }
        public void Add(Car car)
        {

            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            //linq used for to delete 
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }


        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.CarDescription = car.CarDescription;
        }
    }
}