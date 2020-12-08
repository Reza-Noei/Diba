using Diba.Core.AppService.Contract.ProductConstraint.Model.ViewModel;
using Diba.Core.AppService.Contract.ProductStringConstraint.Model.InputModel;

namespace Diba.Core.AppService.Contract.ProductConstraint
{
    public interface IProductStringConstraintsCommandService
    {
        ServiceResult<ProductStringConstraintsViewModel> Create(int id , CreateProductStringConstraintsViewModel model);
        ServiceResult<ProductStringConstraintsViewModel> Update(int productId, int constraintId, UpdateProductStringConstraintsViewModel model);
        ServiceResult<ProductStringConstraintsViewModel> Delete(int id);
    }
}