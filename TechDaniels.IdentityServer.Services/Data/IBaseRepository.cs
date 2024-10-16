using System.Linq.Expressions;
using TechDaniels.IdentityServer.Domain.Base;

namespace TechDaniels.IdentityServer.Services.Data
{
    public interface IBaseRepository<E>
        where E : BaseDbEntity
    {
        IQueryBuilder<E> Where(Expression<Func<E, bool>> filter);
        Task<E> GetById(Guid Id);
        Guid Save(E entity);
        void Save(IEnumerable<E> entity);

    }
}
