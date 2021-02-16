using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;



namespace DataAccess.Abstract
{//Where sonrasında new yazsaydık, newlenebilir bir IEntity yazmamız gerekirdi. IEntity interface olduğu için newlenemez.
    public interface IEntityRepository<T> where T : class, IEntity, new()// T Tipinde birşey getir. Class veya IEntity olabilir.
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);//Expression filtreler yazılmasını sağlar. boş döndürülebilir. Filter=null filtre vermeyede bilinir. Filtre vermemişse tüm datayı getirir.
        T GetById(Expression<Func<T, bool>> filter);//Birşeyin detayına gitmek için kullanılır. 
    }
}
