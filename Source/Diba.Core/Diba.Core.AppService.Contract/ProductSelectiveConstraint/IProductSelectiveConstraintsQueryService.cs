using Diba.Core.AppService.Contract.ProductConstraint.Model.ViewModel;

namespace Diba.Core.AppService.Contract.ProductConstraint
{
    public interface IProductSelectiveConstraintsQueryService
    {
        ServiceResult<ProductSelectiveConstraintsViewModel> Get(int id);
    }
}