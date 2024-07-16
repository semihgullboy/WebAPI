using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAssigmentDal : EfEntityRepositoryBase<Assignment, ApplicationContext>, IAssigmentDal
    {
        private readonly ApplicationContext _context;

        public EfAssigmentDal(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
