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

        public async Task DeleteAsync(int personelId)
        {
            var personel = await  _personelDal.GetAsync(p => p.PersonelID == personelId);
            if (personel != null)
            {
                await _personelDal.DeleteAsync(personel);
            }
        }

        public async Task<List<PersonelViewModel>> GetAllAsync()
        {
            var personels = await _personelDal.GetAllAsync();
            return _mapper.Map<List<PersonelViewModel>>(personels); 
        }

        public async Task<PersonelViewModel> GetByIdAsync(int personelId)
        {
            var personel = await _personelDal.GetAsync(p => p.PersonelID == personelId);
            return _mapper.Map<PersonelViewModel>(personel);
        }

        public async Task<PersonelViewModel> GetByNameAsync(string personelName)
        {
            var personel = await _personelDal.GetAsync(p => p.FirstName == personelName);
            return _mapper.Map<PersonelViewModel>(personel);
        }

        public Task<PersonelDetailsViewModel> GetPersonelWithAllDetailsAsync(int personelId)
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
