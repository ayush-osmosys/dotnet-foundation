using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetFoundation.Presentation.Errors
{
    public class APIException : APIResponce
    {
        public APIException(int StatusCode, string message = null, string details = null) : base(StatusCode, message)
        {
            details = Details;
        }
        public string Details { get; set; }

    }
}