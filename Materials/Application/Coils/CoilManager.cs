using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using SadidServices.Materials.Application.Coils.Contracts;
using SadidServices.Materials.Application.Coils.Contracts.Dtos;
using SadidServices.Materials.Application.Contracts;
using SadidServices.Materials.Domain.Coils;
using CSharpFunctionalExtensions;


namespace SadidServices.Materials.Application.Coils
{
    //Injecting ICoilRepository into CoilManager
    public class CoilManager(ICoilRepository coilRepository, IEmailService emailService) : ICoilManager
    {
        // public async Task<Guid> CreateCoilAsync(CreateCoilDto coilDto)
        //! Create Cenario 
        public async Task<Result<Guid>> CreateCoilAsync(CreateCoilDto coilDto)

        {


            //?Step 1 - Check Coil Uniqness
            var coils = await coilRepository.FindAsync(coil => coil.Serial == coilDto.Serial);
            if (coils.Any())
            {
                // throw new ApplicationException($"Coil with ({coilDto.Serial}) serial number already exists");
                //ApplicationException is a Class Method For Moderating Exceptions...
                //? Because of Using Result Patern we dont need Exceptions, instead we use this
                return Result.Failure<Guid>("This Coil is Exist in Warehouse");
            }

            //?Step 2 - Save To Database
            // Conversion (DTo--->Entity or Entity--->DTo With Mapster)
            var coil = coilDto.Adapt<Coil>();
            await coilRepository.AddAsync(coil);   //Adding Coil To Database

            //?Step 3 - Send Notification to Planners
            await emailService.SendAsync($"Coil With Serial ({coilDto.Serial}) Inserted into Warehouse");
            // return coil.Id;
            return Result.Success(coil.Id);
        }

        //! Update Cenario
        public async Task<Result> UpdateCoilAsync(Guid coilId, UpdateCoilDto coilDto)
        {
            var coils = await coilRepository.FindAsync(coil => coil.Serial == coilDto.Serial && coil.Id != coilId);
            if (coils.Any())
            {

                return Result.Failure<Guid>("This Coil is Exist in Warehouse");
            }

            var coil = await coilRepository.GetByIdAsync(coilId);
            if (coil is null)
            {
                return Result.Failure<Guid>($"Coil with ID: ({coilId})Not Found");

            }
            coilDto.Adapt(coil);
            await coilRepository.UpdateAsync(coil);   //Update Coil To Database

            //?Step 3 - Send Notification to Planners
            await emailService.SendAsync($"Coil With Serial ({coilDto.Serial}) Updated");
            return Result.Success();

        }

        //!Get By ID Cenario
        public async Task<Result<CoilDto>> GetCoilByIdAsync(Guid coilId)
        {
            var coil = await coilRepository.GetByIdAsync(coilId);
            if (coil is null)
            {
                return Result.Failure<CoilDto>($"COil With Id ({coilId}) Not Found");
            }
            var coilDto = coil.Adapt<CoilDto>();
            return coilDto;
        }

        //! Delete Cenario
        public async Task<Result> DeleteCoilAsync(Guid coilId){
            var coil = await coilRepository.GetByIdAsync(coilId);
            if (coil is null){
                return Result.Failure<Guid>("Coil Not Found");
            }
            await coilRepository.DeleteAsync(coil);
            return Result.Success();
            
        }
    }
}