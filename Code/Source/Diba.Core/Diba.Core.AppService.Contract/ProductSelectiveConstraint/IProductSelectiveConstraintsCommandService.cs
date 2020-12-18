using Diba.Core.AppService.Contract.ProductConstraint.Model.ViewModel;
using Diba.Core.AppService.Contract.ProductStringConstraint.Model.InputModel;

namespace Diba.Core.AppService.Contract.ProductConstraint
{
    public interface IProductSelectiveConstraintsCommandService
    {
        ServiceResult<ProductSelectiveConstraintViewModel> Create(int id, CreateProductSelectiveConstraintsViewModel model);
        ServiceResult<ProductSelectiveConstraintViewModel> Update(int productId, int constraintId, UpdateProductSelectiveConstraintsViewModel model);
        ServiceResult<ProductSelectiveConstraintViewModel> Delete(int id);
    }
}
