using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.Domain;
using System.Linq;

namespace Diba.Core.AppService.CustomerManagement
{
    public class CustomerManagementMappingProfile : Profile
    {
        public CustomerManagementMappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Customer, CustomerViewModel>().ConvertUsing(src => new CustomerViewModel()
            {
                Id = src.Id,
                Code = src.Code,
                District = src.District,
                FirstName = src.FirstName,
                LastName = src.LastName,
                //Address = src.ContactInfos.First().Address,
                //PhoneNumber = src.ContactInfos.First().PhoneNumber,
                EconomicCode = src.EconomicCode,
                NationalIdentifier = src.NationalIdentifier,
                PostalCode = src.PostalCode,
                RegistrationNumber = src.RegistrationNumber
            });
        }
    }
}
