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
            var department = _mapper.Map<Department>(entity);
            await _departmentDal.AddAsync(department);
        }

        public async Task DeleteAsync(int departmentID)
        {
            var deparment = await _departmentDal.GetAsync(d => d.DepartmentID == departmentID);
            if (deparment != null)
            {
                await _departmentDal.DeleteAsync(deparment);
            }
        }

        public async Task<List<DepartmentViewModel>> GetAllAsync()
        {
            var departments = await _departmentDal.GetAllAsync();
            return _mapper.Map<List<DepartmentViewModel>>(departments);
        }

        public async Task<DepartmentViewModel> GetByIdAsync(int departmentID)
        {
            var departments = await _departmentDal.GetAsync(d => d.DepartmentID == departmentID);
            return _mapper.Map<DepartmentViewModel>(departments);
        }

        public Task<DepartmentDetailsViewModel> GetDepartmentPersonnelInformationAsync(int departmentID)
        {
            return _departmentDal.GetDepartmentPersonnelInformationAsync(departmentID);
        }

        public Task UpdateAsync(DepartmentViewModel entity)
        {
            var departments = _mapper.Map<Department>(entity);
            return _departmentDal.UpdateAsync(departments);
        }
    }
}
