using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentDetailDto> GetRentDetails() 
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                    join c in context.Cars
                        on r.CarId equals c.CarId /// car tablosun su ıd li car ı getir
                    join cs in context.Customers
                        on r.CustomerId equals cs.Id /// customer tablosundan su id li customer getir.
                    select new RentDetailDto
                    {
                        RentalId = r.Id,
                        CarDescription = c.CarDescription,
                        CampanyName = cs.CompanyName,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate,
                    };
                return result.ToList();
            }

        }

        public Rental GetById(Expression<Func<Rental, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}