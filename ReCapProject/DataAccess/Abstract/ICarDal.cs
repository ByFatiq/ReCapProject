using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetAll();
        List<Car> GetByBrandId(int brandId);
        List<Car> GetByBrandColorId(int ColorId);

        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetByColorId(int colorId);
    }
}
