using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SadidServices.Materials.Domain.Coils;

namespace SadidServices.Materials.Infrastructure.Repositories
{
    public class CoilRepository : Repository<Coil,Guid> , ICoilRepository
    {
        
    }
}