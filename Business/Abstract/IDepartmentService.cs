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
        Task<Department> GetByIdAsync(int departmentID);
        Task<List<Department>> GetAllAsync();
        Task AddAsync(DepartmentDetailsViewModel entity);
        Task DeleteAsync(Department entity);
        Task UpdateAsync(Department entity);
        Task<DepartmentDetailsViewModel> GetDepartmentPersonnelInformationAsync(int departmentID);
    }
}
