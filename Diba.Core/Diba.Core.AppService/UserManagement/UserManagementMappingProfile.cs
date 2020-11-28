using AutoMapper;
using Diba.Core.AppService.Contract.BindingModels;
using Diba.Core.AppService.Contract.ViewModels;
using Diba.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService
{
    public class UserManagementMappingProfile : Profile
    {
        public UserManagementMappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<User, UserViewModel>();
            CreateMap<CreateUserBindingModel, User>();
        }
    }
}
