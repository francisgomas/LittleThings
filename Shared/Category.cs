using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleThings.Shared
{
    public class Category
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public Guid SubCategoryId { get; set; }
        [ForeignKey(nameof(SubCategoryId))]
        public virtual SubCategory SubCategory { get; set; }
        [Required]
        public string ImageURL { get; set; }
    }
}
