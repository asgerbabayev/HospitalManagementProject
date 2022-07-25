using FinalProject.Core.DataAccess.EntityFramework;
using FinalProject.DataAccess.Abstract;
using FinalProject.DataAccess.Concrete.DataContext;
using FinalProject.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
namespace FinalProject.DataAccess.Concrete.EntityFramework
{
    public class EfDoctorDal : EfEntityRepositoryBase<Doctor, Context>, IDoctorDal
    {
        public List<Role> GetClaims(Doctor doctor)
        {
            using (var context = new Context())
            {
                var result = from r in context.Roles
                             join ru in context.Roles on doctor.RoleId equals ru.Id
                             select new Role
                             {
                                 Id = ru.Id,
                                 Name = ru.Name,
                             };
                return result.ToList();

            }
        }
    }
}
