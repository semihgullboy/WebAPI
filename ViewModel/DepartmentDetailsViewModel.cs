using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class DepartmentDetailsViewModel
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public List<PersonelDetailsViewModel>? Personel { get; set; }
    }

}
