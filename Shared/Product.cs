using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleThings.Shared
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category? Category { get; set; }
        public bool Featured { get; set; } = false;
        [Required]
        public string Image { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public decimal OriginalPrice { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;




    }
}
