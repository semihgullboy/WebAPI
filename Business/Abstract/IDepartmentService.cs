using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Business.Abstract
{
    public interface IDepartmentService
    {
        Task<DepartmentViewModel> GetByIdAsync(int departmentID);
        Task<List<DepartmentViewModel>> GetAllAsync();
        Task AddAsync(DepartmentViewModel entity);
        Task DeleteAsync(int departmentID);
        Task UpdateAsync(DepartmentViewModel entity);
        Task<DepartmentDetailsViewModel> GetDepartmentPersonnelInformationAsync(int departmentID);
    }
}
