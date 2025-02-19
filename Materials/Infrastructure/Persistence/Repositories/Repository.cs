using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SadidServices.Materials.Shared.Primitives;
using SadidServices.Materials.Shared.Primitives.Contracts;

namespace SadidServices.Materials.Infrastructure.Persistance.Repositories
{
    //! SQL Server - Oracle - MongoDB or ...
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : notnull
    {
        private Dictionary<TId, TEntity> storage = new();

        public Task<TId> AddAsync(TEntity entity)
        {
            storage.Add(entity.Id, entity);
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(TEntity entity)
        {
            storage.Remove(entity.Id);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<TEntity>> FindAsync(Func<TEntity, bool> predicate)
        {
            return Task.FromResult(storage.Values.Where(predicate));
        }

        public Task<TEntity?> GetByIdAsync(TId id)
        {
            if (storage.ContainsKey(id))
            {
                var entity = storage[id];
                return Task.FromResult(entity);
            }
            return Task.FromResult(default(TEntity));
        }

        public Task UpdateAsync(TEntity entity)
        {
            storage[entity.Id] = entity;
            return Task.CompletedTask;
        }
    }
}