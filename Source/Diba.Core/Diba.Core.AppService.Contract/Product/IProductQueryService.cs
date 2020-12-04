using Diba.Core.AppService.Contract.Product.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Contract.Product
{
    public interface IProductQueryService
    {
        ServiceResult<IEnumerable<ProductViewModel>> GetList();

        ServiceResult<ProductViewModel> Get(int id);
    }
}
