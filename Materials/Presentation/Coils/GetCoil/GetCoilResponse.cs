using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SadidServices.Materials.Presentation.Coils.GetCoil
{
    public record GetCoilResponse(Guid Id,string Serial,string Owner,string Melt,string OwnerWeight,float SadidWeight,string Type,string Size,DateTime TimeReceive,string Description);
}