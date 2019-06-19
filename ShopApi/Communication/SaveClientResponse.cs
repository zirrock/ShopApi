using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopApi.Domain.Models;

namespace ShopApi.Communication
{
    public class SaveClientResponse : BaseResponse
    {
        public Client Client { get; private set; }

        private SaveClientResponse(bool success, string message, Client client) : base(success, message)
        {
            Client = client;
        }

        // Creates a success response
        public SaveClientResponse(Client client) : this(true, string.Empty, client)
        { }

        // Creates an error response
        public SaveClientResponse(string message) : this(false, message, null)
        { }
    }
}
