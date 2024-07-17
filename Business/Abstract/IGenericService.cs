using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenericService<TViewModel>
    {
        Task AddAsync(TViewModel entity);
        Task DeleteAsync(int id);
        Task<List<TViewModel>> GetAllAsync();
        Task<TViewModel> GetByIdAsync(int id);
        Task UpdateAsync(TViewModel entity);
    }
}
