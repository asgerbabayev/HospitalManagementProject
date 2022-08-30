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
    public class EfControlDal : EfEntityRepositoryBase<Control, Context>, IControlDal
    {
        public List<Control> GetControls()
        {
            using (Context context = new Context())
            {
                return context.Controls.Include(x => x.Registry).ToList();
            }
        }
    }
}
