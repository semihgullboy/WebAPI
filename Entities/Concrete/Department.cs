using Core.Entities;

namespace Entities.Concrete
{
    public class Department : IEntity
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Personel> Personels { get; }
    }
}
