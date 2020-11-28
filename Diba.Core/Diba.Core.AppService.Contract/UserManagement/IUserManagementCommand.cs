using Diba.Core.AppService.Contract.BindingModels;
using Diba.Core.AppService.Contract.ViewModels;
using System;

namespace Diba.Core.AppService.Contract
{
    public interface IUserManagementCommand
    {
        ServiceResult<UserViewModel> Create(CreateUserBindingModel request);
    }
}
