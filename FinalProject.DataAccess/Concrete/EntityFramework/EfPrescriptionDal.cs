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
    public class EfPrescriptionDal : EfEntityRepositoryBase<Prescription, Context>, IPrescriptionDal
    {
        public List<Prescription> GetPrescriptionsWithRegistry()
        {
            using (Context context = new Context())
            {
                return context.Prescriptions.Include(x => x.Registry).Include(y => y.Medicine).ToList();
            }
        }

    }
}
