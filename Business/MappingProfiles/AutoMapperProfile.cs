using AutoMapper;
using Entities.Concrete;
using ViewModel;

namespace Business.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PersonelViewModel, Personel>();
            CreateMap<Personel, PersonelViewModel>();
            CreateMap<DepartmentViewModel, Department>();
            CreateMap<Department, DepartmentViewModel>();
            CreateMap<Title, TitleViewModel>();
            CreateMap<TitleViewModel, Title>();
            CreateMap<Project, ProjectViewModel>();
            CreateMap<ProjectViewModel, Project>();
        }
    }
}
