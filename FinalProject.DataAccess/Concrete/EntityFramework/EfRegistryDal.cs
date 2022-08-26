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
    public class EfRegistryDal : EfEntityRepositoryBase<Registry, Context>, IRegistryDal
    {
        public List<Registry> GetAllData()
        {
            using (Context context = new Context())
            {
                return context.Registries.Include(e => e.Employee).Include(r => r.Room).ToList();
            }
        }
    }
}
