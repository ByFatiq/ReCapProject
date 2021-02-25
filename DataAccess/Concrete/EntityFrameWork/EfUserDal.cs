using System;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACarContext>, IUserDal
    {
        public User GetById(Expression<Func<User, bool>> filter)
        {
            using (var context = new RentACarContext())
            {
                var user = context.Users.FirstOrDefault(filter);
               return user;
            }
        }
    }
}