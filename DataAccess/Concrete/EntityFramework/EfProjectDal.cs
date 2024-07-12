using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProjectDal : EfEntityRepositoryBase<Project, ApplicationContext>, IProjectDal
    {
        public EfProjectDal(ApplicationContext context) : base(context)
        {

        }
    }
}
