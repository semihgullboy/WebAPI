using Entities.Concrete;
using ViewModel;

namespace Business.Abstract
{
    public interface IPersonelService
    {
        Task<Personel> GetByIdAsync(int personelId);
        Task<Personel> GetByNameAsync(string personelName);
        Task<List<Personel>> GetAllAsync();
        Task AddAsync(PersonelViewModel viewModel);
        Task DeleteAsync(Personel entity);
        Task UpdateAsync(PersonelViewModel viewModel);
        Task<Personel> GetPersonelWithAllDetailsAsync(int personelId);
    }
}
