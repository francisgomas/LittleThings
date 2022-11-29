using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleThings.Shared
{
    public class Permission
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Controller Name")]
        public string ControllerName { get; set; }
        [Required]
        [Display(Name = "Action Name")]
        public string ActionName { get; set; }
    }
}
