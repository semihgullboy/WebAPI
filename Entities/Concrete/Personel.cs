using Core.Entities;

namespace Entities.Concrete
{
    public class Personel : IEntity
    {
        public int PersonelID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? TitleID { get; set; }
        public int? DepartmentID { get; set; }

        public Title Title { get; set; }
        public Department Department { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
