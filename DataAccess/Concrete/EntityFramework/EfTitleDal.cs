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

        public async Task<TitleDetailsViewModel> GetTitleWithPersonelsAsync(int titleId)
        {
            var title = await _context.Titles
                .Where(t => t.TitleID == titleId)
                .Select(t => new TitleDetailsViewModel
                {
                    TitleID = t.TitleID,
                    TitleName = t.TitleName,
                    Personel = t.Personels.Select(p => new PersonelDetailsViewModel
                    {
                        PersonelID = p.PersonelID,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        Gender = p.Gender,
                        DepartmentName = p.Department.DepartmentName,
                        TitleName = p.Title.TitleName,
                        ProjectNames = p.Assignments.Select(a => a.Project.ProjectName).ToList()
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return title;
        }
    }
}
