using System.ComponentModel;

namespace ES.Domain.API.Enuns
{
    public enum RolesEnum
    {
        [Description("Usuário que acessa ao site e tem poder de compra")]
        User = 0,

        [Description("Fornece os produtos pra mim")]
        Fornecedor = 1,

        [Description("Gestor do Admin")]
        Secretario = 2,

        [Description("Chefão supremo")]
        Admin = 3,
    }
}
