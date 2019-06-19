using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopApi.Domain.Models;

namespace ShopApi.Communication
{
    public class SaveOrderResponse : BaseResponse
    {
        public Order Order { get; private set; }

        private SaveOrderResponse(bool success, string message, Order order) : base(success, message)
        {
            Order = order;
        }

        // Creates a success response
        public SaveOrderResponse(Order order) : this(true, string.Empty, order)
        { }

        // Creates an error response
        public SaveOrderResponse(string message) : this(false, message, null)
        { }
    }
}
