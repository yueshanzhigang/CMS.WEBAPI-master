using CMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CMS.Repository
{
    public class BaseRepository<T> where T:class,new()
    {
        private readonly SqlServerContext _context;

        public BaseRepository(SqlServerContext context)
        {
            _context = context;
        }

        public void Add(T t)
        {
            _context.Set<T>().Add(t);
        }

        public void Delete(T t)
        {
            _context.Set<T>().Remove(t);
        }

        public void Update(T t)
        {
            _context.Set<T>().Update(t);
        }

        public IQueryable<T> GetModels(Expression<Func<T,bool>> whereLambda)
        {
            if (whereLambda==null)
            {
                return _context.Set<T>();
            }
            else
            {
                return _context.Set<T>().Where(whereLambda);
            }
        }

        public IQueryable<T> GetModelsByPage<type>(int pageIndex,int pageSize,bool isAsc,
            Expression<Func<T,bool>> whereLambda,Expression<Func<T,bool>> orderByLambda)
        {
            if (isAsc)
            {
                return _context.Set<T>().Where(whereLambda).OrderBy(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return _context.Set<T>().Where(whereLambda).OrderByDescending(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }

        public IQueryable<T> GetModelsBySql(string sql)
        {
            return _context.Set<T>().FromSqlRaw(sql);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

    }
}
