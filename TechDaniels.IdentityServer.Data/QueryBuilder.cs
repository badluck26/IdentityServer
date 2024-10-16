using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechDaniels.IdentityServer.Domain.Base;
using TechDaniels.IdentityServer.Services.Data;

namespace TechDaniels.IdentityServer.Data
{
    
    public class IncludableQueryBuider<TEntity, TProperty> : QueryBuilder<TEntity>, IIncludableQueryBuilder<TEntity, TProperty>
        where TEntity : BaseDbEntity
    {
        public IncludableQueryBuider(DbSet<TEntity> dbSet) : base(dbSet)
        {
        }

    }

    public class QueryBuilder<TEntity> : IQueryBuilder<TEntity>
            where TEntity : BaseDbEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        protected IQueryable<TEntity> _query;
        

        public QueryBuilder(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
            _query = dbSet;
        }

        public IQueryBuilder<TEntity> OrderByAsc<TProperty>(Expression<Func<TEntity, TProperty>> order)
        {
            _query = _query.OrderBy(order);
            return this; 
        }

        public IQueryBuilder<TEntity> OrderByDesc<TProperty>(Expression<Func<TEntity, TProperty>> order)
        {
            _query = _query.OrderByDescending(order);
            return this;
        }


        public IQueryBuilder<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            _query = _query.Where(predicate);
            return this; 
        }

        public IQueryBuilder<TEntity> And(Expression<Func<TEntity, bool>> predicate)
        {
            _query = _query.Where(predicate);
            return this; 
        }

        public IQueryBuilder<TEntity> Or(Expression<Func<TEntity, bool>> predicate)
        {
            var parameter = predicate.Parameters[0];
            var body = predicate.Body;

            // Create a new expression that combines the existing query with the new predicate
            var combinedPredicate = Expression.Lambda<Func<TEntity, bool>>(
                Expression.OrElse(
                    Expression.Invoke(predicate, parameter),
                    Expression.Invoke(Expression.Constant(_query), parameter)
                ),
                parameter
            );

            _query = _query.Where(combinedPredicate);
            return this;
        }

        private IQueryBuilder<TEntity> Skip(int skip)
        {
            _query = _query.Skip(skip);
            return this;
        }

        private IQueryBuilder<TEntity> Take(int take)
        {
            _query = _query.Take(take);
            return this;
        }

        public IQueryable<TEntity> Build()
        {
            return _query;
        }
    }
}
