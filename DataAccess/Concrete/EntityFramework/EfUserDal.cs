using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ApplicationContext>, IUserDal
    {
        private readonly ApplicationContext _context;

        public EfUserDal(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                            .Include(u => u.UserRole) // Eğer rolü de yüklemek istiyorsanız
                            .SingleOrDefaultAsync(u => u.UserEmail == email);
        }
    }
}
