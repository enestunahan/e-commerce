using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.DataAccess.Abstract
{
   public interface IEntityRepository<T>
    {
        Task<List<T>> GetList(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
