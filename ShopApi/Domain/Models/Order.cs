namespace ShopApi.Domain.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long ProductQuantity { get; set; }
        public long OrderDate { get; set; }

        public long ClientId { get; set; }
        public Client Client { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
