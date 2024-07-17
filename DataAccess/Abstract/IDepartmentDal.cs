using Entities.Concrete;
using ViewModel;

namespace DataAccess.Abstract
{
    public interface IDepartmentDal : IEntityRepository<Department>
    {
        Task<DepartmentDetailsViewModel> GetDepartmentPersonnelInformationAsync(int departmentID);
    }
}
