using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CMS.IServices
{
    public interface IBaseService<T> where T : class, new()
    {
        bool Add(T t);

        bool Update(T t);

        bool Delete(T t);

        IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda = null);

        IQueryable<T> GetModelsByPage<type>(int pageIndex, int pageSize, bool isAsc,
            Expression<Func<T, bool>> orderByLambda, Expression<Func<T, bool>> whereLambda);

        IQueryable<T> GetModelsBySql(string sql);

        bool SaveChanges();
    }
}
