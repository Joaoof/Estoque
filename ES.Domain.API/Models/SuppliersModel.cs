using System;
using System.ComponentModel.DataAnnotations;

namespace ES.Domain.API.Models
{
    public class SupplierModel
    {
        public int Id { get; set; } // Identificador único do fornecedor

        [Required]
        [StringLength(100, ErrorMessage = "O nome do fornecedor não pode exceder 100 caracteres.")]
        public string Name { get; set; } // Nome do fornecedor

        [StringLength(255, ErrorMessage = "A descrição não pode exceder 255 caracteres.")]
        public string Description { get; set; } // Descrição opcional do fornecedor

        [Required]
        [EmailAddress(ErrorMessage = "O email fornecido não é válido.")]
        public string Email { get; set; } // Email de contato do fornecedor

        [Phone(ErrorMessage = "O número de telefone fornecido não é válido.")]
        public string Phone { get; set; } // Número de telefone do fornecedor

        [Required]
        [StringLength(200, ErrorMessage = "O endereço não pode exceder 200 caracteres.")]
        public string Address { get; set; } // Endereço do fornecedor

        public bool IsActive { get; set; } // Status ativo/inativo do fornecedor

        [Required]
        public DateTime DateRegistered { get; set; } // Data de registro do fornecedor

        public DateTime? DateUpdated { get; set; } // Data da última atualização, se houver

        // Relacionamentos com outros modelos, como o estoque de produtos (se aplicável)

        // Se você tiver um relacionamento com os produtos fornecidos pelo fornecedor:
        // public ICollection<Product> Products { get; set; } 
    }
}
