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
    public class EfUserDal : EfEntityRepositoryBase<User, Context>, IUserDal
    {
        public List<Role> GetClaims(User user)
        {
            using (var context = new Context())
            {
                var result = from r in context.Roles
                             join ru in context.Roles on user.RoleId equals ru.Id
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
