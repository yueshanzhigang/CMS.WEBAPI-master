
using CMS.IRepository;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Services
{
    public class BaseService<T> where T : class, new()
    {
        public IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public bool Add(T t)
        {
            _baseRepository.Add(t);
            return _baseRepository.SaveChanges();
        }
        public bool Delete(T t)
        {
            _baseRepository.Delete(t);
            return _baseRepository.SaveChanges();
        }
        public bool Update(T t)
        {
            _baseRepository.Update(t);
            return _baseRepository.SaveChanges();
        }
        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda = null)
        {
            if (whereLambda == null)
            {
                return _baseRepository.GetModels();
            }
            return _baseRepository.GetModels(whereLambda);
        }

        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, bool>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            return _baseRepository.GetModelsByPage<type>(pageSize, pageIndex, isAsc, OrderByLambda, WhereLambda);
        }

        public IQueryable<T> GetModelsBySql(string sql)
        {
            return _baseRepository.GetModelsBySql(sql);
        }

        public bool SaveChanges()
        {
            return _baseRepository.SaveChanges();
        }
    }
}
