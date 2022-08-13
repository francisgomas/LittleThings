using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleThings.Shared
{
    public class SocialMedia
    {
        public int Id { get; set; }
        [Required]
        public string Icon { get; set; } = String.Empty;
        [Required]
        public string Link { get; set; } = String.Empty;
    }
}
