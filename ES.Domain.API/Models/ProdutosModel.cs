public class ProductModel
{
    public int Id { get; set; }                      // Identificador único do produto

    public string Name { get; set; }                 // Nome do produto

    public string Description { get; set; }          // Descrição detalhada do produto

    public string SKUCode { get; set; }              // Código SKU (Stock Keeping Unit) para controle

    public decimal Price { get; set; }               // Preço do produto

    public int StockQuantity { get; set; }           // Quantidade atual em estoque

    public DateTime DateAdded { get; set; }          // Data de inclusão do produto no sistema

    public int CategoryId { get; set; }              // Relacionamento com uma categoria de produto (opcional)

    public decimal Weight { get; set; }              // Peso do produto, útil para cálculo de frete

    public string Location { get; set; }             // Localização no depósito ou armazém

    public bool IsActive { get; set; }               // Status de disponibilidade do produto
}
