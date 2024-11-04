using FluentValidation;
using ES.Domain.API.Models;

namespace ES.Services.API.Validation.Products;

public class ProductsModelValidator : AbstractValidator<ProductsModel>
{
    public ProductsModelValidator()
    {
        // Nome do Produto - Não pode ser vazio e tem um limite de 100 caracteres
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("O nome do produto é obrigatório.")
            .Length(1, 100).WithMessage("O nome do produto deve ter no máximo 100 caracteres.");

        // Código SKU - Não pode ser vazio e tem um limite de 20 caracteres
        RuleFor(p => p.SKUCode)
            .NotEmpty().WithMessage("O código SKU é obrigatório.")
            .Length(1, 20).WithMessage("O código SKU deve ter no máximo 20 caracteres.");

        // Preço - Deve estar no intervalo de 0 a 99999.99
        RuleFor(p => p.Price)
            .GreaterThanOrEqualTo(0).WithMessage("O preço deve ser positivo.")
            .LessThanOrEqualTo(99999.99m).WithMessage("O preço deve ser menor que R$ 100.000,00.");

        // Quantidade em Estoque - Deve ser um número inteiro positivo
        RuleFor(p => p.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("A quantidade em estoque deve ser positiva.");

        // Data de Adição - Deve ser uma data válida e não vazia
        RuleFor(p => p.DateAdded)
            .NotEmpty().WithMessage("A data de adição é obrigatória.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de adição não pode ser futura.");

        // Peso - Deve estar no intervalo de 0 a 999.99
        RuleFor(p => p.Weight)
            .GreaterThanOrEqualTo(0).WithMessage("O peso deve ser positivo.")
            .LessThanOrEqualTo(999.99m).WithMessage("O peso deve ser menor que 1000.");

        // Status Ativo/Inativo - Deve ser obrigatório
        RuleFor(p => p.IsActive)
            .NotNull().WithMessage("O status de atividade do produto é obrigatório.");
    }
}
