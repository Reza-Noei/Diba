using Diba.Core.AppService.Contract.ProductConstraint.Model.ViewModel;

namespace Diba.Core.AppService.Contract.ProductConstraint
{
    public interface IProductStringConstraintsQueryService
    {
        ServiceResult<ProductStringConstraintsViewModel> Get(int id);
    }
}