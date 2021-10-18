using CustomerApi.Common.Models;
using System;

namespace CustomerApi.Common.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(Error error)
        {

            Error = error;
        }

        public Error Error { get; }
    }
}
