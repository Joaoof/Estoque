using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ES.Domain.API.Models
{
    [Table("Categorias", Schema = "estoque")]
    public class CategoriesModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<ProductsModel> Products { get; set; }
    }
}
