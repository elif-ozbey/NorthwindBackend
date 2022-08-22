using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new TContext())    
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
            
        {
            using (var contex = new TContext())
            { 
             var deletedEntity = contex.Entry(entity);
                deletedEntity.State = EntityState.Deleted; 
                contex.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var contex = new TContext()) 
            {
                return contex.Set<TEntity>().SingleOrDefault(filter);

                //bu yine abone olma operasyonu tek bir nesne oldugu icin singleor defaul diyerek filtreye gore gelmesini istiyoruz

            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)

        {
            using (var contex = new TContext())
            {
                return filter == null
                    ? contex.Set<TEntity>().ToList()
                    : contex.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (var contex = new TContext()) 
            {
                var updatedEntity = contex.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                contex.SaveChanges();
            }
        }
    }
}
