using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;
        private readonly IMapper _mapper;

        public DepartmentManager(IDepartmentDal departmentDal, IMapper mapper)
        {
            _departmentDal = departmentDal;
            _mapper = mapper;
        }

        public async Task AddAsync(DepartmentViewModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Eklenecek departman bilgileri geçerli bir referans olmalıdır.");
            }

            var department = _mapper.Map<Department>(entity);
            await _departmentDal.AddAsync(department);
        }

        public async Task DeleteAsync(int departmentID)
        {
            if (departmentID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(departmentID), "Departman ID'si sıfırdan büyük olmalıdır.");
            }

            var department = await _departmentDal.GetAsync(d => d.DepartmentID == departmentID);

            if (department == null)
            {
                throw new Exception($"ID'si {departmentID} olan departman bulunamadı.");
            }

            await _departmentDal.DeleteAsync(department);
        }

        public async Task<List<DepartmentViewModel>> GetAllAsync()
        {
            var departments = await _departmentDal.GetAllAsync();
            return _mapper.Map<List<DepartmentViewModel>>(departments);
        }

        public async Task<DepartmentViewModel> GetByIdAsync(int departmentID)
        {
            if (departmentID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(departmentID), "Departman ID'si sıfırdan büyük olmalıdır.");
            }

            var department = await _departmentDal.GetAsync(d => d.DepartmentID == departmentID);

            if (department == null)
            {
                throw new Exception($"ID'si {departmentID} olan departman bulunamadı.");
            }

            return _mapper.Map<DepartmentViewModel>(department);
        }

        public Task<DepartmentDetailsViewModel> GetDepartmentPersonnelInformationAsync(int departmentID)
        {
            if (departmentID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(departmentID), "Departman ID'si sıfırdan büyük olmalıdır.");
            }

            return _departmentDal.GetDepartmentPersonnelInformationAsync(departmentID);
        }

        public async Task UpdateAsync(DepartmentViewModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Güncellenecek departman bilgileri geçerli bir referans olmalıdır.");
            }

            var department = _mapper.Map<Department>(entity);
            await _departmentDal.UpdateAsync(department);
        }
    }
}
