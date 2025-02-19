using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SadidServices.Materials.Presentation.Coils.CreateCoil
{
    // We Just need Coil Id for Response
    public record CreateCoilResponse(Guid CoilId);
}