using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAssigmentDal : EfEntityRepositoryBase<Assignment, ApplicationContext>, IAssigmentDal
    {
        public EfAssigmentDal(ApplicationContext context) : base(context)
        {

        }
    }
}
