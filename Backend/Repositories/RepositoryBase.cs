
using Microsoft.EntityFrameworkCore;
using ProjectRunAway.Models;
using ProjectRunAway.Repositories.Interfaces;
using System.Linq.Expressions;

namespace ProjectRunAway.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected TableContext TableContext { get; set; }

        public RepositoryBase(TableContext locationContext)
        {
            this.TableContext = locationContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.TableContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.TableContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.TableContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.TableContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.TableContext.Set<T>().Remove(entity);
        }
    }
}
