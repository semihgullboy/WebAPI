using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
