using FinalProject.Core.DataAccess;
using FinalProject.Entities.Concrete;
using System.Collections.Generic;

namespace FinalProject.DataAccess.Abstract
{
    public interface IEmployeeDal : IEntityRepository<Employee>
    {
        List<Role> GetClaims(Employee employee);
    }
}
