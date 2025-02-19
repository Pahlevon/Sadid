using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SadidServices.Materials.Application.Contracts
{
    public interface IEmailService
    {
        Task SendAsync(string message);
    }
}