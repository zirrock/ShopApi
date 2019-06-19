using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApi.Resources
{
    public class SaveOrderResource
    {
        [Required]
        [MaxLength(80)]
        public string ProductName { get; set; }

        [Required]
        public long ProductQuantity { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public long ClientId { get; set; }
    }
}
