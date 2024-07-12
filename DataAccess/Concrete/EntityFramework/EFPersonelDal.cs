using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFPersonelDal : EfEntityRepositoryBase<Personel, ApplicationContext>, IPersonelDal
    {
        private readonly ApplicationContext _context;

        public EFPersonelDal(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Personel> GetPersonelWithAllDetailsAsync(int personelId)
        {
            var personel = await _context.Personels
                .Include(p => p.Department)
                .Include(p => p.Title)
                .Include(p => p.Assignments)
                    .ThenInclude(a => a.Project)
                .FirstOrDefaultAsync(p => p.PersonelID == personelId);

            return personel;
        }

    }
}
