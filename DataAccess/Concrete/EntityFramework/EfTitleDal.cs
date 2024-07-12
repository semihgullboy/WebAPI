using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTitleDal : EfEntityRepositoryBase<Title, ApplicationContext>, ITitleDal
    {
        public EfTitleDal(ApplicationContext context) : base(context)
        {
        }
    }
}
