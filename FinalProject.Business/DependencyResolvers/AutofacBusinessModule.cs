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
            builder.RegisterType<EmployeeManager>().As<IEmployeeService>().SingleInstance();
            builder.RegisterType<EfEmployeeDal>().As<IEmployeeDal>().SingleInstance();

            builder.RegisterType<ClinicManager>().As<IClinicService>().SingleInstance();
            builder.RegisterType<EfClinicDal>().As<IClinicDal>().SingleInstance();

            builder.RegisterType<AddressManager>().As<IAddressService>().SingleInstance();
            builder.RegisterType<EfAddressDal>().As<IAddressDal>().SingleInstance();

            builder.RegisterType<MedicineManager>().As<IMedicineService>().SingleInstance();
            builder.RegisterType<EfMedicineDal>().As<IMedicineDal>().SingleInstance();

            builder.RegisterType<RoomManager>().As<IRoomService>().SingleInstance();
            builder.RegisterType<EfRoomDal>().As<IRoomDal>().SingleInstance();

            builder.RegisterType<StockManager>().As<IStockService>().SingleInstance();
            builder.RegisterType<EfStockDal>().As<IStockDal>().SingleInstance();
            
            builder.RegisterType<RegistryManager>().As<IRegistryService>().SingleInstance();
            builder.RegisterType<EfRegistryDal>().As<IRegistryDal>().SingleInstance();

            builder.RegisterType<PatientManager>().As<IPatientService>().SingleInstance();
            builder.RegisterType<EfPatientDal>().As<IPatientDal>().SingleInstance();

            builder.RegisterType<MaterialManager>().As<IMaterialService>().SingleInstance();
            builder.RegisterType<EfMaterialDal>().As<IMaterialDal>().SingleInstance();

            builder.RegisterType<PrescriptionManager>().As<IPrescriptionService>().SingleInstance();
            builder.RegisterType<EfPrescriptionDal>().As<IPrescriptionDal>().SingleInstance();

            builder.RegisterType<ControlManager>().As<IControlService>().SingleInstance();
            builder.RegisterType<EfControlDal>().As<IControlDal>().SingleInstance();

            builder.RegisterType<AnalysisManager>().As<IAnalysisService>().SingleInstance();
            builder.RegisterType<EfAnalysisDal>().As<IAnalysisDal>().SingleInstance();

            builder.RegisterType<ControlAnalysisManager>().As<IControlAnalysisService>().SingleInstance();
            builder.RegisterType<EfControlAnalysisDal>().As<IControlAnalysisDal>().SingleInstance();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
