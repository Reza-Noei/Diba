using AutoMapper;
using Diba.Core.AppService.Contract;

namespace Diba.Core.AppService.RequestItem
{
    public class RequestItemMappingConfig : Profile
    {
        public RequestItemMappingConfig()
        {
            CreateMap<Domain.RequestItem, RequestItemViewModel>().ReverseMap();
            CreateMap<Domain.RequestItem, CreateOrderRequestItemInputModel>().ReverseMap();
        }
    }
}