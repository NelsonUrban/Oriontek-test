using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApi.Common.Models
{
    class ErrorMessage
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }
    }
}
