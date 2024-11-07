namespace ES.Services.API.Aggregates.ProdutcsAggregates.ProductsViewModels.Response
{
    public class ProductsViewModelResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SKUCode { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }

        public string Location { get; set; }

        public int CategoryId { get; set; }

        public virtual CategoriesViewModelResponse Category { get; set; }
    }
}
