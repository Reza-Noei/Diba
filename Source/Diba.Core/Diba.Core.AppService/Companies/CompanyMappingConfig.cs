using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Companies;

namespace Diba.Core.AppService.Companies
{
    public class CompanyMappingConfig : Profile
    {
        public CompanyMappingConfig()
        {
            CreateMap<Domain.Company, CompanyViewModel>();
            CreateMap<CompanyViewModel, Domain.Company>();

            CreateMap<CreateCompanyInputModel, Domain.Company>();
            CreateMap<Domain.Company, CreateCompanyInputModel>();
        }
    }
}