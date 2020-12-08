using Diba.Core.AppService.Contract.ProductConstraint.Model.ViewModel;
using Diba.Core.AppService.Contract.ProductStringConstraint.Model.InputModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Contract.ProductConstraint
{
    public interface IProductSelectiveConstraintsCommandService
    {
        ServiceResult<ProductSelectiveConstraintsViewModel> Create(int id, CreateProductSelectiveConstraintsViewModel model);
        ServiceResult<ProductSelectiveConstraintsViewModel> Update(int productId, int constraintId, UpdateProductSelectiveConstraintsViewModel model);
        ServiceResult<ProductSelectiveConstraintsViewModel> Delete(int id);
    }
}
