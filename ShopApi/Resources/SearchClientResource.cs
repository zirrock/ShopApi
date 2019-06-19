using System.ComponentModel.DataAnnotations;

namespace ShopApi.Resources
{
    public class SearchClientResource
    {
        [Required] [MaxLength(50)] public string Login { get; set; }

        [Required] [MaxLength(50)] public string Name { get; set; }

        [Required] [MaxLength(50)] public string Surname { get; set; }
    }
}