namespace GeekShopping.ProductAPI.Data.ValueObjects
{
    public class ProductVO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? CategoryName { get; set; }
        public int ImageURL { get; set; }

    }
}
