using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;

namespace ShopApi.Resources
{
    public class ClientResource
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
