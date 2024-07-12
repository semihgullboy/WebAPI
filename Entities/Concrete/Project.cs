using Core.Entities;

namespace Entities.Concrete
{
    public class Project: IEntity
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime PlannedEndDate { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
