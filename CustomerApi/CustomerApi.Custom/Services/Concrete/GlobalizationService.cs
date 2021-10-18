using CustomerApi.Common.Constants;
using CustomerApi.Common.Models;
using CustomerApi.Common.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerApi.Common.Services.Concrete
{   
    public class GlobalizationService : IGlobalizationService
    {
        private IHttpContextAccessor HttpContextAccessor { get; }
        private IConfiguration Configuration { get; }
        private ILogger<GlobalizationService> Logger { get; }

        public GlobalizationService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, ILogger<GlobalizationService> logger)
        {
            Logger = logger;
            HttpContextAccessor = httpContextAccessor;
            Configuration = configuration;
        }
        private string GetCurrentUseLanguagePreference()
        {
            try
            {
                var user = HttpContextAccessor.HttpContext.User;
                return user.Claims.SingleOrDefault(t => t.Type.Equals(Claims.UserLanguagePreference)).Value;
            }
            catch
            {
                Logger.LogWarning("User does not have set a language prefernce, sending response in default language.");
                return Configuration["PreferredLanguage"];
            }
        }
        public Error GetErrorInCurrentLanguage(string errorCode)
        {
            try
            {
                var currentLanguage = GetCurrentUseLanguagePreference();
                var error = Configuration.GetSection("Errors").Get<List<Error>>().SingleOrDefault(t => t.Code.Equals(errorCode) && t.Language.Equals(currentLanguage));
                return error;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Could not find error code. Exception {ex.Message}, InnerExecption:{ex.InnerException?.Message}");
                throw ex;
            }
        }
    }
}

