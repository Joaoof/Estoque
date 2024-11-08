using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ES.Domain.API.Models
{
    [Table("Produtos")]
    public class ProductsModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string SKUCode { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public decimal Weight { get; set; }

        public string Location { get; set; }

        [Required]
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = "Admin";

        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; } = "Admin";

        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual CategoriesModel Categories { get; set; }
    }
}
