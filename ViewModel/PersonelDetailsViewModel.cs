using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PersonelDetailsViewModel
    {
        public int PersonelID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DepartmentName { get; set; }
        public string TitleName { get; set; }
        public List<string> ProjectNames { get; set; }
    }

}
