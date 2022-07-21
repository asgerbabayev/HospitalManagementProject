using FinalProject.Core.DataAccess;
using FinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<Role> GetClaims(User kullanici);
    }
}
