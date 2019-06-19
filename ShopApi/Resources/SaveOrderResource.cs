using System.ComponentModel.DataAnnotations;

namespace ShopApi.Resources
{
    public class SaveOrderResource
    {
        [Required] [MaxLength(80)] public string ProductName { get; set; }

        [Required] public long ProductQuantity { get; set; }

        [Required] public bool IsDeleted { get; set; }

        [Required] public long ClientId { get; set; }
    }
}