namespace ShopApi.Domain.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long ProductQuantity { get; set; }
        public string ProductName { get; set; }
        public long OrderDate { get; set; }
        public bool IsDeleted { get; set; } = false;

        public long ClientId { get; set; }
        public Client Client { get; set; }
    }
}
