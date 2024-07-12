using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAssigmentService
    {
        Task<List<Assignment>> GetAllAsync();
        Task<Assignment> GetByIdAsync(int id);
        Task AddAsync(Assignment entity);
        Task DeleteAsync(Assignment entity);
        Task UpdateAsync(Assignment entity);
    }
}
