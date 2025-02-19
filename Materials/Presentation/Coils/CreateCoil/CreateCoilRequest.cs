using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SadidServices.Materials.Presentation.Coils.CreateCoil
{
  public record CreateCoilRequest(string Serial,string Owner,string Melt,string OwnerWeight,float SadidWeight,string Type,string Size,DateTime TimeReceive,string Description)
  {

  }
   
}