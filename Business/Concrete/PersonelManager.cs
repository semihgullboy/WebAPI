using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Logging;
using ViewModel;

namespace Business.Concrete
{
    public class PersonelManager : IPersonelService
    {
        private readonly IPersonelDal _personelDal;
        private readonly IMapper _mapper;
        private readonly ILogger<PersonelManager> _logger; // ILogger ekleyin

        public PersonelManager(IPersonelDal personelDal, IMapper mapper, ILogger<PersonelManager> logger)
        {
            _personelDal = personelDal;
            _mapper = mapper;
            _logger = logger; // Logger'ı kullanın
        }

        public async Task AddAsync(PersonelViewModel viewModel)
        {
            if (viewModel == null)
            {
                _logger.LogError("Personel ekleme işlemi sırasında geçersiz viewModel gönderildi.");
                throw new ArgumentNullException(nameof(viewModel), "Eklenecek personel bilgileri geçerli bir referans olmalıdır.");
            }

            try
            {
                var personel = _mapper.Map<Personel>(viewModel);
                await _personelDal.AddAsync(personel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Personel eklenirken hata oluştu.");
                throw;
            }
        }

        public async Task DeleteAsync(int personelId)
        {
            if (personelId <= 0)
            {
                _logger.LogError("Geçersiz PersonelID: {PersonelId}. Personel silme işlemi gerçekleştirilemedi.", personelId);
                throw new ArgumentOutOfRangeException(nameof(personelId), "Personel ID'si sıfırdan büyük olmalıdır.");
            }

            try
            {
                var personel = await _personelDal.GetAsync(p => p.PersonelID == personelId);

                if (personel == null)
                {
                    _logger.LogWarning("ID'si {PersonelId} olan personel bulunamadı.", personelId);
                    throw new Exception($"ID'si {personelId} olan personel bulunamadı.");
                }

                await _personelDal.DeleteAsync(personel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Personel silinirken hata oluştu.");
                throw;
            }
        }

        public async Task<List<PersonelViewModel>> GetAllAsync()
        {
            try
            {
                var personels = await _personelDal.GetAllAsync();
                return _mapper.Map<List<PersonelViewModel>>(personels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Tüm personeller alınırken hata oluştu.");
                throw;
            }
        }

        public async Task<PersonelViewModel> GetByIdAsync(int personelId)
        {
            if (personelId <= 0)
            {
                _logger.LogError("Geçersiz PersonelID: {PersonelId}. Personel bilgileri alınamadı.", personelId);
                throw new ArgumentOutOfRangeException(nameof(personelId), "Personel ID'si sıfırdan büyük olmalıdır.");
            }

            try
            {
                var personel = await _personelDal.GetAsync(p => p.PersonelID == personelId);

                if (personel == null)
                {
                    _logger.LogWarning("ID'si {PersonelId} olan personel bulunamadı.", personelId);
                    throw new Exception($"ID'si {personelId} olan personel bulunamadı.");
                }

                return _mapper.Map<PersonelViewModel>(personel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Personel bilgileri alınırken hata oluştu.");
                throw;
            }
        }

        public async Task<PersonelViewModel> GetByNameAsync(string personelName)
        {
            if (string.IsNullOrWhiteSpace(personelName))
            {
                _logger.LogError("Geçersiz personel adı: {PersonelName}. Personel bilgileri alınamadı.", personelName);
                throw new ArgumentNullException(nameof(personelName), "Personel adı geçerli bir değer içermelidir.");
            }

            try
            {
                var personel = await _personelDal.GetAsync(p => p.FirstName == personelName);

                if (personel == null)
                {
                    _logger.LogWarning("Adı '{PersonelName}' olan personel bulunamadı.", personelName);
                    throw new Exception($"Adı '{personelName}' olan personel bulunamadı.");
                }

                return _mapper.Map<PersonelViewModel>(personel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Personel adı ile arama yapılırken hata oluştu.");
                throw;
            }
        }

        public Task<PersonelDetailsViewModel> GetPersonelWithAllDetailsAsync(int personelId)
        {
            if (personelId <= 0)
            {
                _logger.LogError("Geçersiz PersonelID: {PersonelId}. Personel detayları alınamadı.", personelId);
                throw new ArgumentOutOfRangeException(nameof(personelId), "Personel ID'si sıfırdan büyük olmalıdır.");
            }

            return _personelDal.GetPersonelWithAllDetailsAsync(personelId);
        }

        public async Task UpdateAsync(PersonelViewModel viewModel)
        {
            if (viewModel == null)
            {
                _logger.LogError("Personel güncelleme işlemi sırasında geçersiz viewModel gönderildi.");
                throw new ArgumentNullException(nameof(viewModel), "Güncellenecek personel bilgileri geçerli bir referans olmalıdır.");
            }

            try
            {
                var personel = _mapper.Map<Personel>(viewModel);
                await _personelDal.UpdateAsync(personel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Personel güncellenirken hata oluştu.");
                throw;
            }
        }
    }
}
