using CustomerApi.Common.Services.Abstract;
using CustomerApi.Common.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApi.Common.Configurations.DependencyInjection
{
    public static partial class GlobalizationServiceConfiguration
    {
        public static void ConfigureGlobalizationService(this IServiceCollection services)
        {
            services.AddTransient<IGlobalizationService, GlobalizationService>();
        }
    }
}
