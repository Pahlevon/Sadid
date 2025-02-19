using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SadidServices.Materials.Infrastructure.Persistence
{
    // This Class should Interact with Configurations
    //? COil
    //? Coil Configuration
    //? SQL Server Address => Connection String (UserId , Password, Server, Database)
    public class CatalogContext : DbContext
    {

    //? Developing SQL Server Address => Connection String (UserId , Password, Server, Database)
    //! Injecting Option Pattern To Proive String For CatalogContext. DbContextOptions Is For EF Options.
    public CatalogContext(DbContextOptions<CatalogContext> options):base (options)
    {
        // Now We Can Send With option to Parent.
        //Addding New Service into DI.

    }

    }
}