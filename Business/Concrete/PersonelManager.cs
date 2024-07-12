using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using ViewModel;

namespace Business.Concrete
{
    public class PersonelManager : IPersonelService
    {
        private readonly IPersonelDal _personelDal;
        private readonly IMapper _mapper;

        public PersonelManager(IPersonelDal personelDal, IMapper mapper)
        {
            _personelDal = personelDal;
            _mapper = mapper;
        }

        public Task AddAsync(PersonelViewModel viewModel)
        {
            var personel = _mapper.Map<Personel>(viewModel);
            return _personelDal.AddAsync(personel);
        }

        public Task DeleteAsync(Personel entity)
        {
            return _personelDal.DeleteAsync(entity);
        }

        public Task<List<Personel>> GetAllAsync()
        {
            return _personelDal.GetAllAsync();
        }

        public Task<Personel> GetByIdAsync(int personelId)
        {
            return _personelDal.GetAsync(p => p.PersonelID == personelId);
        }

        public Task<Personel> GetByNameAsync(string personelName)
        {
            return _personelDal.GetAsync(p => p.FirstName == personelName);
        }

        public Task<Personel> GetPersonelWithAllDetailsAsync(int personelId)
        {
            return _personelDal.GetPersonelWithAllDetailsAsync(personelId);
        }

        public Task UpdateAsync(PersonelViewModel viewModel)
        {
            var personel = _mapper.Map<Personel>(viewModel);
            return _personelDal.UpdateAsync(personel);
        }

    }
}
