using Diba.Core.AppService.Contract.BindingModels;
using Diba.Core.AppService.Contract.ViewModels;
using System.Collections.Generic;

namespace Diba.Core.AppService.Contract
{
    public interface IUserManagementQuery
    {
        ServiceResult<UserViewModel> Get(GetUserBindingModel request);
        ServiceResult<IList<UserViewModel>> GetAll(GetAllUserBindingModel getAllUserBindingModel);
    }
}