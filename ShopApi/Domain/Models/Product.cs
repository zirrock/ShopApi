using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApi.Domain.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IList<Order> Orders { get; set; } = new List<Order>();
    }
}
