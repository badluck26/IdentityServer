using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechDaniels.IdentityServer.Domain.Base;

namespace TechDaniels.IdentityServer.Services.Data
{
    public interface IQueryBuilder<TEntity> where TEntity : BaseDbEntity
    {
        IQueryBuilder<TEntity> OrderByAsc<TProperty>(Expression<Func<TEntity, TProperty>> order);
        IQueryBuilder<TEntity> OrderByDesc<TProperty>(Expression<Func<TEntity, TProperty>> order);
        IQueryBuilder<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        IQueryBuilder<TEntity> And(Expression<Func<TEntity, bool>> predicate);
        IQueryBuilder<TEntity> Or(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Build();
    }

    public interface IIncludableQueryBuilder<TEntity, TProperty> : IQueryBuilder<TEntity>
        where TEntity : BaseDbEntity
    {
    }

    public static class QueryBuilderExtensions
    {
        public static async Task<TEntity> FindOne<TEntity>(this IQueryBuilder<TEntity> query)
            where TEntity : BaseDbEntity
        {
            return await query.Build().FirstOrDefaultAsync();
        }

        public static async Task<IEnumerable<TEntity>> FindAll<TEntity>(this IQueryBuilder<TEntity> query)
            where TEntity : BaseDbEntity
        {
            return await query.Build().ToListAsync();
        }

        public static async Task<bool> Any<TEntity>(this IQueryBuilder<TEntity> query)
            where TEntity : BaseDbEntity
        {
            return await query.Build().AnyAsync();
        }

        public static async Task<(int count, IEnumerable<TEntity> list)> FindPaginated<TEntity>(this IQueryBuilder<TEntity> query, int skip = 0, int take = 10)
            where TEntity : BaseDbEntity
        {
            var builtQuery = query.Build();

            var count = await builtQuery.CountAsync();

            var data = await builtQuery.Skip(skip).Take(take).ToListAsync();

            return (count, data);
        }


        public static IIncludableQueryBuilder<TEntity, TProperty> Include<TEntity, TProperty>(
            this IQueryBuilder<TEntity> source,
            Expression<Func<TEntity, TProperty>> include)
            where TEntity : BaseDbEntity
        {
            return source.Include(include);
        }

        public static IIncludableQueryBuilder<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
            this IIncludableQueryBuilder<TEntity, TPreviousProperty> source,
            Expression<Func<TPreviousProperty, TProperty>> include)
            where TEntity : BaseDbEntity
        {
            return source.ThenInclude(include);
        }

        public static IIncludableQueryBuilder<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
            this IIncludableQueryBuilder<TEntity, ICollection<TPreviousProperty>> source,
            Expression<Func<TPreviousProperty, TProperty>> include)
            where TEntity : BaseDbEntity
        {
            return source.ThenInclude(include);
        }
    }

}
