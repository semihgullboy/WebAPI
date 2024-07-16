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
        }
    }
}
