using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IPersonelDal : IEntityRepository<Personel>
    {
        Task<Personel> GetPersonelWithAllDetailsAsync(int personelId);
    }
}
