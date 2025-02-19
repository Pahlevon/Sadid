using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SadidServices.Materials.Application.Common
{
    public class ApplicationException : Exception
    {
        public ApplicationException(string message):base(message)
        {
            
        }
    }
}