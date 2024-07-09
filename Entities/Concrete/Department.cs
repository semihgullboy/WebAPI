namespace Entities.Concrete
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Personel> Personels { get; }
    }
}
