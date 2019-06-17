namespace ShopApi.Domain.Models
{
    public class Order
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public long OrderDate { get; set; }
    }
}
