using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using ViewModel;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDepartmentDal : EfEntityRepositoryBase<Department, ApplicationContext>, IDepartmentDal
    {
        private readonly ApplicationContext _context;

        public EfDepartmentDal(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<DepartmentViewModel> GetDepartmentPersonnelInformationAsync(int departmentID)
        {
            var department = await _context.Departments
                .Where(d => d.DepartmentID == departmentID)
                .Select(d => new DepartmentViewModel
                {
                    DepartmentID = d.DepartmentID,
                    DepartmentName = d.DepartmentName,
                    Personnel = d.Personels.Select(p => new PersonelDetailsViewModel
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

            return department;

        }
    }
}
