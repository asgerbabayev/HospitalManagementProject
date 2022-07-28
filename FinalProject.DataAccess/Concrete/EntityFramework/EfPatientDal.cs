using FinalProject.Core.DataAccess.EntityFramework;
using FinalProject.DataAccess.Abstract;
using FinalProject.DataAccess.Concrete.DataContext;
using FinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.DataAccess.Concrete.EntityFramework
{
    public class EfPatientDal : EfEntityRepositoryBase<Patient, Context>, IPatientDal
    {
    }
}
