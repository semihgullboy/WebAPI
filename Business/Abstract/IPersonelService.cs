using Entities.Concrete;
using ViewModel;

namespace Business.Abstract
{
    public interface IPersonelService
    {
        Task<PersonelViewModel> GetByIdAsync(int personelId);
        Task<PersonelViewModel> GetByNameAsync(string personelName);
        Task<List<PersonelViewModel>> GetAllAsync();
        Task AddAsync(PersonelViewModel viewModel);
        Task DeleteAsync(int personelId);
        Task UpdateAsync(PersonelViewModel viewModel);
        Task<PersonelDetailsViewModel> GetPersonelWithAllDetailsAsync(int personelId);
    }
}
