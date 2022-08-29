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
    public class EfMaterialDal : EfEntityRepositoryBase<Material, Context>, IMaterialDal
    {
        public Material GetMaterial(int id)
        {
            using (Context context = new Context())
            {
                return context.Materials.Include(x => x.Registry).Include(y => y.Stock).FirstOrDefault();
            }
        }
    }
}
