using CustomerApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApi.Common.Services.Abstract
{
    public interface IGlobalizationService
    {
        Error GetErrorInCurrentLanguage(string errorCode);
    }
}
