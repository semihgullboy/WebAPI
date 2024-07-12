using Core.Entities;

namespace Entities.Concrete
{
    public class Title : IEntity
    {
        public int TitleID { get; set; }
        public string? TitleName { get; set; }

        public virtual ICollection<Personel>? Personels { get; set; }
    }
}
