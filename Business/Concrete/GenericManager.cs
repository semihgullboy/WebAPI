using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GenericManager<TViewModel, TEntity> : IGenericService<TViewModel> where TEntity : class
    {
        private readonly IEntityRepository<TEntity> _entityRepository;
        private readonly IMapper _mapper;

        public GenericManager(IEntityRepository<TEntity> entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(TViewModel entity)
        {
            var model = _mapper.Map<TEntity>(entity);
            await _entityRepository.AddAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var models = await _entityRepository.GetAllAsync();

            var model = models.FirstOrDefault(m => (int)m.GetType().GetProperty("TitleID").GetValue(m) == id);
            if (model != null)
            {
                await _entityRepository.DeleteAsync(model);
            }
        }

        public async Task<List<TViewModel>> GetAllAsync()
        {
            var models = await _entityRepository.GetAllAsync();
            return _mapper.Map<List<TViewModel>>(models);
        }

        public async Task<TViewModel> GetByIdAsync(int id)
        {
            var models = await _entityRepository.GetAllAsync(); 

            var model = models.FirstOrDefault(m => (int)m.GetType().GetProperty("TitleID").GetValue(m) == id);

            return _mapper.Map<TViewModel>(model);
        }


        public async Task UpdateAsync(TViewModel entity)
        {
            var model = _mapper.Map<TEntity>(entity);
            await _entityRepository.UpdateAsync(model);
        }
    }
}
