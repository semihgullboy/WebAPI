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

        public Task AddAsync(DepartmentViewModel entity)
        {
            var department = _mapper.Map<Department>(entity);
            return _departmentDal.AddAsync(department);
        }

        public Task DeleteAsync(Department entity)
        {
            return _departmentDal.DeleteAsync(entity);
        }

        public Task<List<Department>> GetAllAsync()
        {
            return _departmentDal.GetAllAsync();
        }

        public Task<Department> GetByIdAsync(int departmentID)
        {
            return _departmentDal.GetAsync(d => d.DepartmentID == departmentID);
        }

        public Task<DepartmentViewModel> GetDepartmentPersonnelInformationAsync(int departmentID)
        {
            return _departmentDal.GetDepartmentPersonnelInformationAsync(departmentID);
        }

        public Task UpdateAsync(Department entity)
        {
            return _departmentDal.UpdateAsync(entity);
        }
    }
}
