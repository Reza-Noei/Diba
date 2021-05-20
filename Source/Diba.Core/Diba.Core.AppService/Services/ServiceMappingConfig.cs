using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Services;
using Diba.Core.Domain;

namespace Diba.Core.AppService.Services
{
    public class ServiceMappingConfig : Profile
    {
        public ServiceMappingConfig()
        {
            CreateMap<Service, ServiceViewModel>();
            CreateMap<ServiceViewModel, Service>();

            CreateMap<CreateServiceInputModel, Service>();
            CreateMap<Service, CreateServiceInputModel>();
        }
    }
}