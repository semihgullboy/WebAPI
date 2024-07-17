using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Business.Abstract
{
    public interface IProjectService
    {
        Task AddAsync(ProjectViewModel entity);
        Task DeleteAsync(int id);
        Task<List<ProjectViewModel>> GetAllAsync();
        Task<ProjectViewModel> GetByIdAsync(int id);
        Task UpdateAsync(ProjectViewModel entity);
    }
}
