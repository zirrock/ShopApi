using ShopApi.Domain.Models;

namespace ShopApi.Communication
{
    public class OrderResponse : BaseResponse
    {
        private OrderResponse(bool success, string message, Order order) : base(success, message)
        {
            Order = order;
        }

        // Creates a success response
        public OrderResponse(Order order) : this(true, string.Empty, order)
        {
        }

        // Creates an error response
        public OrderResponse(string message) : this(false, message, null)
        {
        }

        public Order Order { get; }
    }
}