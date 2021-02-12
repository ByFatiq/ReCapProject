using ReCapProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ReCapProject.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //Expression ile GetAll içerisinde filtre verilebilmesi sağlanır. Örneğin; p=p.ColorId==2 şeklnde yazmamızı sağlar.
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
