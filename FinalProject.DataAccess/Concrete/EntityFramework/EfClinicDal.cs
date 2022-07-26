using FinalProject.Core.DataAccess.EntityFramework;
using FinalProject.DataAccess.Abstract;
using FinalProject.DataAccess.Concrete.DataContext;
using FinalProject.Entities.Concrete;

namespace FinalProject.DataAccess.Concrete.EntityFramework
{
    public class EfClinicDal:EfEntityRepositoryBase<Clinic,Context>,IClinicDal
    {
    }
}
