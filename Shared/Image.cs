using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleThings.Shared
{
    public class Image
    {
        public int Id { get; set; }
        [Required]
        public string ImageURL {get;set;}
    }
}
