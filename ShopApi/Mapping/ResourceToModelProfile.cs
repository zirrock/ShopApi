using AutoMapper;
using ShopApi.Domain.Models;
using ShopApi.Resources;

namespace ShopApi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveClientResource, Client>();
            CreateMap<SaveOrderResource, Order>();
        }
    }
}