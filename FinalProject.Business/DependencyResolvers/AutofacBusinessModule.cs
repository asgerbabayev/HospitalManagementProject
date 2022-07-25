using Autofac;
using FinalProject.Business.Abstract;
using FinalProject.Business.Concrete;
using FinalProject.Business.ValidationRules.FluentValidation;
using FinalProject.Core.Utilities.Security.JWT;
using FinalProject.Core.Utilities.Security.Mail;
using FinalProject.DataAccess.Abstract;
using FinalProject.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DoctorManager>().As<IDoctorService>().SingleInstance();
            builder.RegisterType<EfDoctorDal>().As<IDoctorDal>().SingleInstance();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
