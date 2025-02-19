using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carter;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SadidServices.Materials.Application.Coils.Contracts;
using SadidServices.Materials.Application.Coils.Contracts.Dtos;
using SadidServices.Materials.Domain.Coils;
using SadidServices.Materials.Presentation.Coils.UpdateCoil;
namespace SadidServices.Materials.Presentation.Coils.DeleteCoil
{
    //We Use Carter Module For Developing Endpoints
    public class DeleteCoilEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/coils/{coilId}", Handler)
            .WithTags(EndpointTags.Coils)
            .WithName("DeleteCoil")
            .WithSummary("Delete Coil")
            .WithDescription("This endpoint permanently deletes a coil by its ID");


        }
        //All The EndPoints USe IResult For Handlers
        //Presentation Just Can Connect With Application Then We Use ICoilManager Form Application Layer.
        async Task<IResult> Handler([FromRoute]Guid coilId, [FromServices] ICoilManager coilManager)
        {
            var DeleteCoilResult = await coilManager.DeleteCoilAsync(coilId);
            if (DeleteCoilResult.IsSuccess)
            {
                var response = new DeleteCoilResponse(true);
                return TypedResults.Ok(response);
            }
            else
            {
                return Results.BadRequest(DeleteCoilResult.Error);
            }

        }


    }

}
