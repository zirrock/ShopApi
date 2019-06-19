using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApi.Domain.Models
{
    public class Client
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Phone] public string Phone { get; set; }

        public IList<Order> Orders { get; set; } = new List<Order>();
    }
}