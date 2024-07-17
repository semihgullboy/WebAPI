using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using ViewModel;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTitleDal : EfEntityRepositoryBase<Title, ApplicationContext>, ITitleDal
    {
        private readonly ApplicationContext _context;

        public EfTitleDal(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Title> GetTitleWithPersonelsAsync(int titleId)
        {
            return await _context.Titles
                .Include(t => t.Personels)
                .FirstOrDefaultAsync(t => t.TitleID == titleId);
        }
    }
}
