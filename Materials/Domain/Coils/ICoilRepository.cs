using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SadidServices.Materials.Shared.Primitives.Contracts;

namespace SadidServices.Materials.Domain.Coils
{
    public interface ICoilRepository : IRepository<Coil, Guid>
    {
        
    }
}
