using Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected InsuranceDBContext _dbContext;
        public RepositoryBase(InsuranceDBContext insuranceDBContext) { 
            this._dbContext = insuranceDBContext;
        }
        public bool Create(T entity)
        {
            var result = _dbContext.Set<T>().Add(entity);
            if(result.State == EntityState.Added)
            {
                return true;
            }
            return false;
        }

        public bool Delete(T entity)
        {
            var result = _dbContext.Set<T>().Remove(entity);
            if (result.State == EntityState.Deleted)
            {
                return true;
            }
            return false;
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ? _dbContext.Set<T>().AsNoTracking() : _dbContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ? _dbContext.Set<T>().Where(expression).AsNoTracking() 
                : _dbContext.Set<T>().Where(expression);

        }

        public bool Update(T entity)
        {
            var result = _dbContext.Set<T>().Update(entity);
            if (result.State == EntityState.Modified)
            {
                return true;
            }
            return false;
        }
    }
}
