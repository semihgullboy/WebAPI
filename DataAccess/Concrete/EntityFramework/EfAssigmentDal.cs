using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAssigmentDal : EfEntityRepositoryBase<Assignment, ApplicationContext>, IAssigmentDal
    {
        public EfAssigmentDal(ApplicationContext context) : base(context)
        {

        }
    }
}
