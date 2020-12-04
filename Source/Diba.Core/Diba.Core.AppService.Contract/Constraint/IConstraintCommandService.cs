using Diba.Core.AppService.Contract.Constraint.Model.ViewModels;

namespace Diba.Core.AppService.Contract.Constraint
{
    public interface IConstraintCommandService
    {
        ServiceResult<ConstraintViewModel> Create(string name);
    }
}
