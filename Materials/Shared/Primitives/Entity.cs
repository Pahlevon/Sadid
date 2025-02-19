using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SadidServices.Materials.Shared.Primitives.Contracts;

namespace SadidServices.Materials.Shared.Primitives
{
    public abstract class Entity<TId> : IEntity<TId>
    where TId : notnull
    {
        public TId Id {get; private set;}
        public Entity(TId id)
        {
            Id = id;
        }
    }
}