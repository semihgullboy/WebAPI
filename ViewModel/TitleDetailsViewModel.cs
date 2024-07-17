using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class TitleDetailsViewModel
    {
        public int TitleID { get; set; }
        public string TitleName { get; set; }
        public List<PersonelDetailsViewModel>? Personel { get; set; }
    }
}
