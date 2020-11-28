using Diba.Core.AppService.Contract.BindingModels;

namespace Diba.Core.AppService.Contract
{
    public interface IAuthenticationCommand
    {
        ServiceResult<string> FirstStepLogin(UserAuthenticationBindingModel model);
        ServiceResult<string> SecondStepLogin(MembershipAuthenticationBindingModel model);
    }
}
