using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carter;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SadidServices.Materials.Application.Coils.Contracts;
using SadidServices.Materials.Application.Coils.Contracts.Dtos;

namespace SadidServices.Materials.Presentation.Coils.GetCoil
{
    //We Use Carter Module For Developing Endpoints
    public class GetCoilEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/coils/{CoilId}", Handler)
            .WithTags(EndpointTags.Coils)
            .WithName("GetCoil")
            .WithSummary("Get Coil")
            .WithDescription("Gets Coil From Database");

        }

        async Task<IResult> Handler([FromRoute] Guid coilId, [FromServices] ICoilManager coilManager)
        {
            var GetCoilResult = await coilManager.GetCoilByIdAsync(coilId);
            if (GetCoilResult.IsSuccess)
            {
                var coilDto = GetCoilResult.Value;
                var response = coilDto.Adapt<GetCoilResponse>();
                return TypedResults.Ok(response);
            }
            else
            {
                return Results.BadRequest(GetCoilResult.Error);
            }

        }


    }

}