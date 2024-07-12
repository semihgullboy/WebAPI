using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDepartmentDal : EfEntityRepositoryBase<Department, ApplicationContext>, IDepartmentDal
    {
        public EfDepartmentDal(ApplicationContext context) : base(context)
        {

        }
    }
}
