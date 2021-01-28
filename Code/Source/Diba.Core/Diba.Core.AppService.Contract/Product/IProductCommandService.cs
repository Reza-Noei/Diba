using Diba.Core.AppService.Contract.Product.Model.InputModels;
using Diba.Core.AppService.Contract.Product.Model.ViewModels;

namespace Diba.Core.AppService.Contract.Product
{
    public interface IProductCommandService
    {
        ServiceResult<ProductViewModel> Create(CreateProductViewModel model);
        ServiceResult<ProductViewModel> Update(int id, UpdateProductViewModel model);
        ServiceResult<ProductViewModel> Delete(int id);
    }
}
