using CustomerApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace CustomerApi.Common.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;
        public IEnumerable<Error> Errors { get; set; } = new List<Error>();
        public object StockCode { get; set; }
    }
}
