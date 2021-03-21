using Diba.Core.AppService.Contract;
using System.Collections.Generic;

namespace Diba.Core.AppService.Contract
{
    public interface IOrdersQueryService
    {
        ServiceResult<OrderViewModel> Get(int id);
        ServiceResult<IList<OrderViewModel>> GetAll();
    }
}