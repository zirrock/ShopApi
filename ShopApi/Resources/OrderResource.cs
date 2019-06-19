namespace ShopApi.Resources
{
    public class OrderResource
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public long ProductQuantity { get; set; }
        public bool IsDeleted { get; set; }
        public ClientResource Client { get; set; }
    }
}