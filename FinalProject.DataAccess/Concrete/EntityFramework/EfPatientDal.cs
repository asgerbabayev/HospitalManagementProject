using FinalProject.Core.DataAccess.EntityFramework;
using FinalProject.DataAccess.Abstract;
using FinalProject.DataAccess.Concrete.DataContext;
using FinalProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject.DataAccess.Concrete.EntityFramework
{
    public class EfPatientDal : EfEntityRepositoryBase<Patient, Context>, IPatientDal
    {
        public List<Patient> GetPatientsWithRegistry()
        {
            using (Context context = new Context())
            {
                return context.Patients.Include(x => x.Registry).ToList();
            }
        }

        public Patient GetPatient(int id)
        {
            using (Context context = new Context())
            {
                return context.Patients.Include(x => x.Registry).ThenInclude(y => y.Employee).Include(z => z.Registry).ThenInclude(d => d.Room).FirstOrDefault(x=>x.Id == id);
            }
        }
    }
}
