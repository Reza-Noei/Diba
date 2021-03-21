using AutoMapper;
using Diba.Core.AppService.Contract.Order;

namespace Diba.Core.AppService.Order
{
    public class OrderMappingConfig : Profile
    {
        public OrderMappingConfig()
        {
            CreateMap<Domain.Order, OrderViewModel>();
            CreateMap<OrderViewModel, Domain.Order>();

            CreateMap<CreateOrderInputModel, Domain.Order>();
            CreateMap<Domain.Order, CreateOrderInputModel>();
        }
    }
}