using Entities.Concrete;
using ViewModel;

namespace DataAccess.Abstract
{
    public interface IPersonelDal : IEntityRepository<Personel>
    {
        Task<PersonelDetailsViewModel> GetPersonelWithAllDetailsAsync(int personelId);
    }
}
