namespace Skinet.Storage.Redis.Entities
{
    public class BasketItemDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public string ProductBrand { get; set; }
        public string ProductType { get; set; }
    }
}