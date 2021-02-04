using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=01,ColorId=0001,ModelYear=2018,UnitInStock=18,DailyPrice=280,Description="A Segment"},
                new Car{CarId=2,BrandId=02,ColorId=0002,ModelYear=2017,UnitInStock=12,DailyPrice=250,Description="A Segment"},
                new Car{CarId=3,BrandId=03,ColorId=0003,ModelYear=2019,UnitInStock=8,DailyPrice=310,Description="B Segment"},
                new Car{CarId=4,BrandId=04,ColorId=0004,ModelYear=2021,UnitInStock=14,DailyPrice=580,Description="E Segment"},
                new Car{CarId=5,BrandId=05,ColorId=0005,ModelYear=2020,UnitInStock=22,DailyPrice=490,Description="E Segment"},
                new Car{CarId=6,BrandId=06,ColorId=0006,ModelYear=2017,UnitInStock=34,DailyPrice=300,Description="C Segment"},
                new Car{CarId=7,BrandId=07,ColorId=0007,ModelYear=2021,UnitInStock=7,DailyPrice=650,Description="F Segment"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public List<Car> GetByColorId(int colorId)
        {
            return _cars.Where(p => p.ColorId == colorId).ToList();
        }

        public List<Car> GetByBrandColorId(int ColorId)
        {
            throw new NotImplementedException();
        }
    }
}
