using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public async Task<IResult> AddAsync(DepartmentViewModel entity)
        {
            var department = _mapper.Map<Department>(entity);
            await _departmentDal.AddAsync(department);

            return new SuccessResult(Messages.DepartmentAdded);
        }

        public async Task<IResult> DeleteAsync(int departmentID)
        {
            if (departmentID <= 0)
            {
                return new ErrorResult(Messages.DepartmentIdInvalid);
            }

            var department = await _departmentDal.GetAsync(d => d.DepartmentID == departmentID);

            if (department == null)
            {
                return new ErrorResult(Messages.DepartmentIdNotFound);
            }

            await _departmentDal.DeleteAsync(department);
            return new SuccessResult(Messages.DepartmentDeleted);
        }

        public async Task<IDataResult<List<DepartmentViewModel>>> GetAllAsync()
        {
            var departments = await _departmentDal.GetAllAsync();
            var departmentViewModels = _mapper.Map<List<DepartmentViewModel>>(departments);
            return new SuccessDataResult<List<DepartmentViewModel>>(departmentViewModels,Messages.DepartmentsListed);
        }

        public async Task<IDataResult<DepartmentViewModel>> GetByIdAsync(int departmentID)
        {
            if (departmentID <= 0)
            {
                return new ErrorDataResult<DepartmentViewModel>(Messages.DepartmentIdInvalid);
            }

            var department = await _departmentDal.GetAsync(d => d.DepartmentID == departmentID);

            if (department == null)
            {
                return new ErrorDataResult<DepartmentViewModel>(Messages.DepartmentIdNotFound);
            }

            var departmentViewModel = _mapper.Map<DepartmentViewModel>(department);
            return new SuccessDataResult<DepartmentViewModel>(departmentViewModel, Messages.DepartmentListed);
        }

        public async Task<IDataResult<DepartmentDetailsViewModel>> GetDepartmentPersonnelInformationAsync(int departmentID)
        {
            if (departmentID <= 0)
            {
                return new ErrorDataResult<DepartmentDetailsViewModel>(Messages.DepartmentIdInvalid);
            }

            var department = await _departmentDal.GetDepartmentPersonnelInformationAsync(departmentID);

            if (department == null)
            {
                return new ErrorDataResult<DepartmentDetailsViewModel>(Messages.DepartmentIdNotFound);
            }

            var departmentViewModel = _mapper.Map<DepartmentDetailsViewModel>(department);
            return new SuccessDataResult<DepartmentDetailsViewModel>(departmentViewModel, Messages.DepartmentPersonnelListedSuccessfully);
        }

        public async Task<IResult> UpdateAsync(DepartmentViewModel entity)
        {
            var department = _mapper.Map<Department>(entity);
            await _departmentDal.UpdateAsync(department);

            return new SuccessResult(Messages.DepartmentUpdated);
        }
    }
}
