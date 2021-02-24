using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.Domain;

namespace Diba.Core.AppService
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Admin, AdminViewModel>();
            CreateMap<Secretary, SecretaryViewModel>();
            CreateMap<SuperAdmin, SuperAdminViewModel>();
            CreateMap<Collector, CollectorViewModel>();
            CreateMap<Delivery, DeliveryViewModel>();
        }
    }
}