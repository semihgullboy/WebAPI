using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonelService
    {
        Task<List<Personel>> GetAllAsync();
        Task<Personel> GetByIdAsync(int id);
        Task AddAsync(Personel entity);
        Task DeleteAsync(Personel entity);
        Task UpdateAsync(Personel entity);
    }
}
