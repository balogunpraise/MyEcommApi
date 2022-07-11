using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerce.Api.Errors
{
    public class ApiResponses
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponses(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetErrorMessage(statusCode);
        }

        private string GetErrorMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "You have made a bad request",
                401 => "You are not authorized",
                404 => "Resource not found",
                500 => "Internal Server Error",
                _=> null
            };
        }
    }
}
