using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SadidServices.Materials.Shared.Primitives.Contracts
{
    //Domain Driven Design Has =>> //Identifier
    //Using Persistance Ignorance Principal
    public interface IEntity<TId>
    //!Constraints
    where TId:notnull
    {
        TId Id { get;}
    }
}