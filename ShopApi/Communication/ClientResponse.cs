using ShopApi.Domain.Models;

namespace ShopApi.Communication
{
    public class ClientResponse : BaseResponse
    {
        private ClientResponse(bool success, string message, Client client) : base(success, message)
        {
            Client = client;
        }

        // Creates a success response
        public ClientResponse(Client client) : this(true, string.Empty, client)
        {
        }

        // Creates an error response
        public ClientResponse(string message) : this(false, message, null)
        {
        }

        public Client Client { get; }
    }
}