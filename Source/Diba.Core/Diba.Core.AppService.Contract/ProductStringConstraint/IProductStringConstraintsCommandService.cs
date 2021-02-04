using Diba.Core.AppService.Contract.ProductConstraint.Model.ViewModel;
using Diba.Core.AppService.Contract.ProductStringConstraint.Model.InputModel;

namespace Diba.Core.AppService.Contract.ProductConstraint
{
    public interface IProductStringConstraintsCommandService
    {
        ServiceResult<ProductStringConstraintViewModel> Create(int id , CreateProductStringConstraintsViewModel model);
        ServiceResult<ProductStringConstraintViewModel> Update(int productId, int constraintId, UpdateProductStringConstraintsViewModel model);
        ServiceResult<ProductStringConstraintViewModel> Delete(int id);
    }
}