using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ES.Domain.API.Models
{
    [Table("Produtos", Schema = "estoque")]
    public class ProductsModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(20)]
        public string SKUCode { get; set; }

        [Required]
        [Range(0, 99999.99)]
        public decimal Price { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(0, 999.99)]
        public decimal Weight { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
