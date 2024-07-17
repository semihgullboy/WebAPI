using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using ViewModel;

namespace Business.Concrete
{
    public class TitleManager : GenericManager<TitleViewModel, Title>, ITitleService
    {
        public TitleManager(IEntityRepository<Title> _entityRepository, IMapper mapper)
            : base(_entityRepository, mapper)
        {
        }
    }
}
