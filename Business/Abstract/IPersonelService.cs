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
    public interface IPersonelService
    {
        Task<Personel> GetByIdAsync(int personelId);
        Task<Personel> GetByNameAsync(string personelName);
        Task <List<Personel>> GetAllAsync();
        Task AddAsync(PersonelViewModel viewModel);
        Task DeleteAsync(Personel entity);
        Task UpdateAsync(PersonelViewModel viewModel);
        Task<Personel> GetPersonelWithAllDetailsAsync(int personelId);
    }
}
