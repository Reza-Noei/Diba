using Diba.Core.AppService.Contract.Product.Model.InputModels;
using Diba.Core.AppService.Contract.Product.Model.ViewModels;

namespace Diba.Core.AppService.Contract.Product
{
    public interface IProductCommandService
    {
        ServiceResult<ProductViewModel> CreateFinalProduct(CreateFinalProductViewModel model);
        ServiceResult<ProductViewModel> CreateGenericProduct(CreateGenericProductViewModel model);
        ServiceResult<ProductViewModel> UpdateFinalProduct(UpdateFinalProductViewModel model);
        ServiceResult<ProductViewModel> UpdateGenericProduct(UpdateGenericProductViewModel model);
        ServiceResult<ProductViewModel> Delete(int id);
    }
}
