using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleThings.Shared
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
        [Required]
        [Display(Name ="Role Description")]
        public string RoleDescription { get; set; }
    }
}
