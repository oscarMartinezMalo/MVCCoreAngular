using AutoMapper;
using MVCCoreAngular.Data.Entities;
using MVCCoreAngular.ViewModels;

namespace MVCCoreAngular.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
                .ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>()
                .ReverseMap();
        }
    }
}
