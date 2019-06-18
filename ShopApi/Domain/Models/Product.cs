using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApi.Domain.Models
{
    public class Product
    {
        public long Id;
        public string Name;
        public IList<Order> Orders;
    }
}
