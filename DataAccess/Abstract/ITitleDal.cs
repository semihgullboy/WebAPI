using Entities.Concrete;
using ViewModel;

namespace DataAccess.Abstract
{
    public interface ITitleDal : IEntityRepository<Title>
    {
        Task<Title> GetTitleWithPersonelsAsync(int titleId);
    }
}
