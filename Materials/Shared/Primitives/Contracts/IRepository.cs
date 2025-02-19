using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SadidServices.Materials.Shared.Primitives.Contracts
{
    // Repository Patern
    public interface IRepository<TEntity,TId>
    where TEntity : Entity<TId>
    where TId:notnull
    {
        Task<TId> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(TId id);

        //! Query Side
        // Task<IEnumerable<TEntity>> FindAsync();
        //? Delegate(Func , Action , Convertor , Comparer)
        Task<IEnumerable<TEntity>> FindAsync(Func<TEntity , bool> predicate);

    }
}

