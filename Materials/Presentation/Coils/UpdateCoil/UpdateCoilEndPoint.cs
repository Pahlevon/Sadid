using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carter;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SadidServices.Materials.Application.Coils.Contracts;
using SadidServices.Materials.Application.Coils.Contracts.Dtos;

namespace SadidServices.Materials.Presentation.Coils.UpdateCoil
{
    //We Use Carter Module For Developing Endpoints
    public class UpdateCoilEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/coils/{coilId}", Handler)
            .WithTags(EndpointTags.Coils)
            .WithName("UpdateCoil")
            .WithSummary("Update Coil")
            .WithDescription("This EndPoint Updating Coil And Save it into Database");

        }
        //All The EndPoints USe IResult For Handlers
        //Presentation Just Can Connect With Application Then We Use ICoilManager Form Application Layer.
        async Task<IResult> Handler([FromRoute]Guid coilId,[FromBody] UpdateCoilRequest request, [FromServices] ICoilManager coilManager)
        {
            var updateCoilDto = request.Adapt<UpdateCoilDto>();
            var updateCoilResult = await coilManager.UpdateCoilAsync(coilId , updateCoilDto);
            if (updateCoilResult.IsSuccess)
            {
                var response = new UpdateCoilResponse(true);
                return TypedResults.Ok(response);
            }
            else
            {
                return Results.BadRequest(updateCoilResult.Error);
            }

        }


    }

}