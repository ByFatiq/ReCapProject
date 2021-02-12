using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ReCapProject.Entities.DTOs;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.BrandId
                    join cl in context.Colors
                        on c.ColorId equals cl.ColorId
                    select new CarDetailDto
                    {
                        CarId = c.CarId,
                        BrandName = b.BrandName,
                        ColorName = cl.ColorName,
                        DailyPrice = c.DailyPrice,
                        Description = c.CarDescription,
                        ModelYear = c.ModelYear
                    };
                return result.ToList();
            }

        }
    }
}