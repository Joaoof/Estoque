using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ES.Domain.API.Models
{
    [Table("Usuarios", Schema = "estoque")]
    public class UsersModel
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(80, ErrorMessage = "Nome não pode exceder 80 caracteres")]
        public string Name { get; set; }

        [EmailAddress]
        [Required, MaxLength(120)]
        public string Email { get; set; }

        [PasswordPropertyText]
        [Required]
        public string Password { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
