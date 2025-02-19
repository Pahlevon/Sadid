using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carter;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SadidServices.Materials.Application.Coils.Contracts;
using SadidServices.Materials.Application.Coils.Contracts.Dtos;

namespace SadidServices.Materials.Presentation.Coils.CreateCoil
{
    //We Use Carter Module For Developing Endpoints
    public class CreateCoilEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/coils", Handler)
            .WithTags(EndpointTags.Coils)
            .WithName("CreateCoil")
            .WithSummary("Create Coil")
            .WithDescription("This EndPoint Creating Coil And Save it into Database And Generate Coil ID");

        }
        //All The EndPoints USe IResult For Handlers
        //Presentation Just Can Connect With Application Then We Use ICoilManager Form Application Layer.
        async Task<IResult> Handler([FromBody] CreateCoilRequest request, [FromServices] ICoilManager coilManager)
        {
            var createCoilDto = request.Adapt<CreateCoilDto>();
            var createCoilResult = await coilManager.CreateCoilAsync(createCoilDto);
            if (createCoilResult.IsSuccess)
            {
                var coilId = createCoilResult.Value;
                var response = new CreateCoilResponse(coilId);
                return TypedResults.Ok(response);
            }
            else
            {
                return Results.BadRequest(createCoilResult.Error);
            }

        }


    }

}