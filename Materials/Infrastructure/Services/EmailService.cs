using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SadidServices.Materials.Application.Contracts;

namespace SadidServices.Materials.Infrastructure.Repositories.Services
{
    public class EmailService(ILogger<EmailService> logger) : IEmailService
    {
        public Task SendAsync(string message)
        {
            logger.LogInformation("Send Email,{0}",message);
            return Task.CompletedTask;
        }
    }
}