using Microsoft.EntityFrameworkCore;
using Shop.Core.DataAccess.Abstract;
using Shop.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<Tentity, Tcontext> : IEntityRepository<Tentity> 
        where Tentity: class,IEntity,new()
        where Tcontext : DbContext , new()

    {
        public Tentity Add(Tentity entity)
        {
            using (Tcontext context = new Tcontext())
            {
                var addedEntity = context.Add(entity).Entity; // sondaki entity bana eklenen son şeyi geri döndüren metotdur                                                             // addedEntity.State = EntityState.Added               
                context.SaveChanges();
                return addedEntity;
            }
        }

        public void Delete(Tentity entity)
        {
            using (Tcontext context = new Tcontext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Tentity Get(Expression<Func<Tentity, bool>> filter)
        {
            using (Tcontext context = new Tcontext())
            {
                return context.Set<Tentity>().SingleOrDefault(filter);
            }
        }

        public async Task<List<Tentity>>  GetList(Expression<Func<Tentity, bool>> filter = null)
        {
            using (Tcontext context = new Tcontext())
            {
                //return await filter == null ? context.Set<Tentity>().ToListAsync()
                //                      : context.Set<Tentity>().Where(filter).ToListAsync();

                if (filter == null)
                {
                    return await context.Set<Tentity>().ToListAsync();
                }
                return await context.Set<Tentity>().Where(filter).ToListAsync();
            }
        }

        public virtual void Update(Tentity entity)
        {
            using (Tcontext context = new Tcontext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
