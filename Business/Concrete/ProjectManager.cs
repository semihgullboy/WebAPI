using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        private readonly IProjectDal _projectDal;
        private readonly IMapper _mapper;

        public ProjectManager(IProjectDal projectDal , IMapper mapper)
        {
            _projectDal = projectDal;
            _mapper = mapper;
        }

        public async Task AddAsync(ProjectViewModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Eklenecek proje bilgileri geçerli bir referans olmalıdır.");
            }

            var project = _mapper.Map<Project>(entity);
            await _projectDal.AddAsync(project);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Proje ID'si sıfırdan büyük olmalıdır.");
            }

            var project = await _projectDal.GetAsync(p => p.ProjectID == id);

            if (project == null)
            {
                throw new Exception($"ID'si {id} olan proje bulunamadı.");
            }

            await _projectDal.DeleteAsync(project);
        }

        public async Task<List<ProjectViewModel>> GetAllAsync()
        {
            var projects = await _projectDal.GetAllAsync();
            return _mapper.Map<List<ProjectViewModel>>(projects);
        }

        public async Task<ProjectViewModel> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Proje ID'si sıfırdan büyük olmalıdır.");
            }

            var project = await _projectDal.GetAsync(p => p.ProjectID == id);

            if (project == null)
            {
                throw new Exception($"ID'si {id} olan proje bulunamadı.");
            }

            return _mapper.Map<ProjectViewModel>(project);
        }

        public async Task UpdateAsync(ProjectViewModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Güncellenecek proje bilgileri geçerli bir referans olmalıdır.");
            }

            var project = _mapper.Map<Project>(entity);
            await _projectDal.UpdateAsync(project);
        }
    }
}
