using AutoMapper;
using Diba.Core.AppService.Contract.RequestItem;

namespace Diba.Core.AppService.RequestItem
{
    public class RequestItemMappingConfig : Profile
    {
        public RequestItemMappingConfig()
        {
            CreateMap<Domain.RequestItem, RequestItemViewModel>();
        }
    }
}