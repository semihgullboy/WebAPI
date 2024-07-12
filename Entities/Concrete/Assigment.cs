using Core.Entities;

namespace Entities.Concrete
{
    public class Assignment : IEntity
    {
        public int AssignmentID { get; set; }
        public int ProjectID { get; set; }
        public int PersonelID { get; set; }

        public virtual Project Project { get; set; }
        public virtual Personel Personel { get; set; }
    }
}
