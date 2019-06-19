using AutoMapper;
using ShopApi.Domain.Models;
using ShopApi.Resources;

namespace ShopApi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Client, ClientResource>();
            CreateMap<Order, OrderResource>();
        }
    }
}