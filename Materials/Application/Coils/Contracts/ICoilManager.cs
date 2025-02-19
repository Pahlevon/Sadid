using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using SadidServices.Materials.Application.Coils.Contracts.Dtos;

namespace SadidServices.Materials.Application.Coils.Contracts
{
    //! DTO ==> Data Transfer Object =>تمام ورودی های لایه اپ باید از نوع (دی تی او) باشد

    public interface ICoilManager
    {
        // void CreateCoil ();
        // Task CreateCoilAsync ();
        Task<Result<Guid>> CreateCoilAsync(CreateCoilDto coilDto);  //Used Result From Result Patern in CSharpFunctional
        Task<Result> UpdateCoilAsync(Guid coilId, UpdateCoilDto coilDto); //We Get Coil Id and Updating the Rest.
        Task<Result<CoilDto>> GetCoilByIdAsync(Guid coilId); //We Get Coil Id and Updating the Rest.
        Task<Result> DeleteCoilAsync(Guid coilId);
    


    }
}