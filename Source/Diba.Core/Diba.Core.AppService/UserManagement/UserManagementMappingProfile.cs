using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.ViewModels;
using Diba.Core.Domain;

namespace Diba.Core.AppService
{
    public class UserManagementMappingProfile : Profile
    {
        public UserManagementMappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<User, UserViewModel>();
            CreateMap<CreateUserInputModel, User>();

            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CreateCustomerInputModel, Customer>();
        }
    }
}
