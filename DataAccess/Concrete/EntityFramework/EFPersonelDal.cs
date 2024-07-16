using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using ViewModel;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFPersonelDal : EfEntityRepositoryBase<Personel, ApplicationContext>, IPersonelDal
    {
        private readonly ApplicationContext _context;

        public EFPersonelDal(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PersonelDetailsViewModel> GetPersonelWithAllDetailsAsync(int personelId)
        {
            var personel = await _context.Personels
                .Where(p => p.PersonelID == personelId)
                .Select(p => new PersonelDetailsViewModel
                {
                    PersonelID = p.PersonelID,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Gender = p.Gender,
                    DepartmentName = p.Department.DepartmentName,
                    TitleName = p.Title.TitleName,
                    ProjectNames = p.Assignments.Select(a => a.Project.ProjectName).ToList()
                })
                .FirstOrDefaultAsync();

            return personel;
        }
    }
}
