using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.Models
{
    public class Error
    {
        public string Message { get; }
        public ErrorCode ErrorCode { get; }

        public Error(string message, ErrorCode errorCode)
        {
            Message = message;
            ErrorCode = errorCode;
        }
    }
}