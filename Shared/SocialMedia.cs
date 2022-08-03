using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleThings.Shared
{
    public class SocialMedia
    {
        public int Id { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public string Link { get; set; }
        [Required]
        public bool InNewTab { get; set; }
    }
}
