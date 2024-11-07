using ES.Domain.API.Enuns;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ES.Domain.API.Models
{
    [Table("UserRoles", Schema = "estoque")]
    public class UserRolesModel
    {
        [Key]
        public int Id { get; set; }

        public RolesEnum RoleName { get; set; }

        public ICollection<UsersModel> Users { get; set; }
    }
}
