using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonelManager : IPersonelService
    {
        private readonly IPersonelDal _personelDal;

        public PersonelManager(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }

        public Task AddAsync(Personel entity)
        {
            return _personelDal.AddAsync(entity);
        }

        public Task DeleteAsync(Personel entity)
        {
            return _personelDal.DeleteAsync(entity);
        }

        public Task<List<Personel>> GetAllAsync()
        {
           return _personelDal.GetAllAsync();
        }

        public Task<Personel> GetByIdAsync(int id)
        {
            return _personelDal.GetByIdAsync(id);
        }

        public Task UpdateAsync(Personel entity)
        {
            return _personelDal.UpdateAsync(entity);
        }
    }
}
