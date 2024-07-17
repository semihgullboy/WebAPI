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

        public async Task AddAsync(PersonelViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel), "Eklenecek personel bilgileri geçerli bir referans olmalıdır.");
            }

            var personel = _mapper.Map<Personel>(viewModel);
            await _personelDal.AddAsync(personel);
        }

        public async Task DeleteAsync(int personelId)
        {
            if (personelId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(personelId), "Personel ID'si sıfırdan büyük olmalıdır.");
            }

            var personel = await _personelDal.GetAsync(p => p.PersonelID == personelId);

            if (personel == null)
            {
                throw new Exception($"ID'si {personelId} olan personel bulunamadı.");
            }

            await _personelDal.DeleteAsync(personel);
        }

        public async Task<List<PersonelViewModel>> GetAllAsync()
        {
            var personels = await _personelDal.GetAllAsync();
            return _mapper.Map<List<PersonelViewModel>>(personels);
        }

        public async Task<PersonelViewModel> GetByIdAsync(int personelId)
        {
            if (personelId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(personelId), "Personel ID'si sıfırdan büyük olmalıdır.");
            }

            var personel = await _personelDal.GetAsync(p => p.PersonelID == personelId);

            if (personel == null)
            {
                throw new Exception($"ID'si {personelId} olan personel bulunamadı.");
            }

            return _mapper.Map<PersonelViewModel>(personel);
        }

        public async Task<PersonelViewModel> GetByNameAsync(string personelName)
        {
            if (string.IsNullOrWhiteSpace(personelName))
            {
                throw new ArgumentNullException(nameof(personelName), "Personel adı geçerli bir değer içermelidir.");
            }

            var personel = await _personelDal.GetAsync(p => p.FirstName == personelName);

            if (personel == null)
            {
                throw new Exception($"Adı '{personelName}' olan personel bulunamadı.");
            }

            return _mapper.Map<PersonelViewModel>(personel);
        }

        public Task<PersonelDetailsViewModel> GetPersonelWithAllDetailsAsync(int personelId)
        {
            if (personelId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(personelId), "Personel ID'si sıfırdan büyük olmalıdır.");
            }

            return _personelDal.GetPersonelWithAllDetailsAsync(personelId);
        }

        public async Task UpdateAsync(PersonelViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel), "Güncellenecek personel bilgileri geçerli bir referans olmalıdır.");
            }

            var personel = _mapper.Map<Personel>(viewModel);
            await _personelDal.UpdateAsync(personel);
        }


    }
}
