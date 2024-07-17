using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Business.Abstract
{
    public interface ITitleService 
    {
        Task AddAsync(TitleViewModel entity);
        Task DeleteAsync(int id);
        Task<List<TitleViewModel>> GetAllAsync();
        Task<TitleViewModel> GetByIdAsync(int id);
        Task UpdateAsync(TitleViewModel entity);
        Task<Title> GetTitleWithPersonelsAsync(int titleId);
    }
}
