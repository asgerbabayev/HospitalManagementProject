using FinalProject.Core.DataAccess;
using FinalProject.Entities.Concrete;
using System.Collections.Generic;

namespace FinalProject.DataAccess.Abstract
{
    public interface IDoctorDal : IEntityRepository<Doctor>
    {
        List<Role> GetClaims(Doctor doctor);
    }
}
