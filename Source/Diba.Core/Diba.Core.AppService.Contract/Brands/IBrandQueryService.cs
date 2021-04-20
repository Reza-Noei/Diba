using System.Collections.Generic;

namespace Diba.Core.AppService.Contract.Brands
{
    public interface IBrandQueryService
    {
        ServiceResult<BrandViewModel> Get(long id);
        ServiceResult<IEnumerable<BrandViewModel>> GetAll();
    }
}