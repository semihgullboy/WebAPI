using AutoMapper;
using Business.Abstract;
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
            var title = _mapper.Map<Title>(entity);
            await _titleDal.AddAsync(title);
        }

        public async Task DeleteAsync(int titleID)
        {
            var title = await _titleDal.GetAsync(t => t.TitleID == titleID);

            if (title != null)
            {
                await _titleDal.DeleteAsync(title);
            }
        }

        public async Task<List<TitleViewModel>> GetAllAsync()
        {
            var titles = await _titleDal.GetAllAsync();
            return _mapper.Map<List<TitleViewModel>>(titles);
        }

        public async Task<TitleViewModel> GetByIdAsync(int titleID)
        {
            var title = await _titleDal.GetAsync(t => t.TitleID == titleID);
            return _mapper.Map<TitleViewModel>(title);
        }

        public Task<TitleDetailsViewModel> GetTitleWithPersonelsAsync(int titleId)
        {
            return _titleDal.GetTitleWithPersonelsAsync(titleId);
        }

        public async Task UpdateAsync(TitleViewModel entity)
        {
            var title = _mapper.Map<Title>(entity);
            await _titleDal.UpdateAsync(title);
        }
    }
}



