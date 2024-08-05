using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [StringLength(50)]
        public string RoleName { get; set; }

        [StringLength(200)]
        public string RoleDescription { get; set; }
        public bool IsActive { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
