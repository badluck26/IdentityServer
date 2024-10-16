using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechDaniels.IdentityServer.Domain.Base;
using TechDaniels.IdentityServer.Services.Data;

namespace TechDaniels.IdentityServer.Data.Base
{
    public class BaseRepository<E> : IBaseRepository<E>
        where E:BaseDbEntity
    {
        private readonly IdentityServerDbContext DbContext;
        private DbSet<E> _dbSet;

        public BaseRepository(IdentityServerDbContext dbContext)
        {
            this.DbContext = dbContext;
            _dbSet = DbContext.Set<E>();
        }

        public IQueryBuilder<E> Where(Expression<Func<E, bool>> filter)
        {
            var query =  new QueryBuilder<E>(_dbSet);

            return query.Where(filter);
        }

        public async Task<E> GetById(Guid Id)
        {
            return await _dbSet.SingleOrDefaultAsync(w => w.Id == Id);
        }

        public Guid Save(E entity) { 
            if(entity.Id.HasValue)
            {
                _dbSet.Update(entity);
            } else
            {
                entity.Id = Guid.NewGuid();
                _dbSet.Add(entity);
            }

            return entity.Id.Value;
        }

        public void Save(IEnumerable<E> entities)
        {
            foreach (var entity in entities) Save(entity);
        }
    }
}
