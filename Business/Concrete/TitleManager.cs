using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using ViewModel;

namespace Business.Concrete
{
    public class TitleManager : ITitleService
    {
        private readonly ITitleDal _titleDal;
        private readonly IMapper _mapper;

        public TitleManager(ITitleDal titleDal, IMapper mapper)
        {
            _titleDal = titleDal;
            _mapper = mapper;
        }

        public async Task AddAsync(TitleViewModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Eklenecek başlık bilgileri null olmamalıdır.");
            }

            var title = _mapper.Map<Title>(entity);
            await _titleDal.AddAsync(title);
        }

        public async Task DeleteAsync(int titleID)
        {
            if (titleID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(titleID), "Başlık ID'si sıfırdan büyük olmalıdır.");
            }

            var title = await _titleDal.GetAsync(t => t.TitleID == titleID);

            if (title == null)
            {
                throw new Exception($"ID'si {titleID} olan başlık bulunamadı.");
            }

            await _titleDal.DeleteAsync(title);
        }

        public async Task<List<TitleViewModel>> GetAllAsync()
        {
            var titles = await _titleDal.GetAllAsync();
            return _mapper.Map<List<TitleViewModel>>(titles);
        }

        public async Task<TitleViewModel> GetByIdAsync(int titleID)
        {
            if (titleID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(titleID), "Başlık ID'si sıfırdan büyük olmalıdır.");
            }

            var title = await _titleDal.GetAsync(t => t.TitleID == titleID);

            if (title == null)
            {
                throw new Exception($"ID'si {titleID} olan başlık bulunamadı.");
            }

            return _mapper.Map<TitleViewModel>(title);
        }


        public Task<TitleDetailsViewModel> GetTitleWithPersonelsAsync(int titleID)
        {
            if (titleID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(titleID), "Başlık ID'si sıfırdan büyük olmalıdır.");
            }

            return _titleDal.GetTitleWithPersonelsAsync(titleID);
        }

        public async Task UpdateAsync(TitleViewModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Güncellenecek başlık bilgileri null olmamalıdır.");
            }

            var title = _mapper.Map<Title>(entity);
            await _titleDal.UpdateAsync(title);
        }
    }
}



