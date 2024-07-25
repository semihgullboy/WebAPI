using Core.Utilities.Results;
using ViewModel;

namespace Business.Abstract
{
    public interface IDepartmentService
    {
        Task<IDataResult<DepartmentViewModel>> GetByIdAsync(int departmentID);
        Task<IDataResult<List<DepartmentViewModel>>> GetAllAsync();
        Task<IResult> AddAsync(DepartmentViewModel entity);
        Task<IResult> DeleteAsync(int departmentID);
        Task<IResult> UpdateAsync(DepartmentViewModel entity);
        Task<IDataResult<DepartmentDetailsViewModel>> GetDepartmentPersonnelInformationAsync(int departmentID);
    }
}
