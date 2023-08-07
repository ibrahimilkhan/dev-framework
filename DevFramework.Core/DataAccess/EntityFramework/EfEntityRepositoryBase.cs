using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntitiyRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntry = context.Entry(entity);
                addedEntry.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntry = context.Entry(entity);
                deletedEntry.State = EntityState.Deleted;
                context.SaveChanges();
            };
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                if (filter == null)
                {
                    return context.Set<TEntity>().ToList();
                }
                else
                {
                    return context.Set<TEntity>().Where(filter).ToList();
                }
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntry = context.Entry(entity);
                updatedEntry.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }
    }
}
