using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AssigmentManager : IAssigmentService
    {
        private readonly IAssigmentDal _assigmentDal;

        public AssigmentManager(IAssigmentDal assigmentDal)
        {
            _assigmentDal = assigmentDal;
        }

        public Task AddAsync(Assignment entity)
        {
            return _assigmentDal.AddAsync(entity);
        }

        public Task DeleteAsync(Assignment entity)
        {
            return _assigmentDal.DeleteAsync(entity);
        }

        public Task<List<Assignment>> GetAllAsync()
        {
            return _assigmentDal.GetAllAsync();
        }

        public Task<Assignment> GetByIdAsync(int id)
        {
            return _assigmentDal.GetAsync(a => a.AssignmentID == id);
        }

        public Task UpdateAsync(Assignment entity)
        {
            return _assigmentDal.UpdateAsync(entity);
        }
    }
}
