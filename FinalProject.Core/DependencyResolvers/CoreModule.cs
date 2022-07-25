using FinalProject.Core.Utilities.IoC;
using FinalProject.Core.Utilities.Mappings;
using FinalProject.Core.Utilities.Security.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {

        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(MappingProfile));
            serviceCollection.AddSingleton<MailHelper>();
        }
    }
}
