using System.Collections.Generic;

namespace Diba.Core.AppService.Contract.Services
{
    public interface IServiceQueryService
    {
        ServiceResult<ServiceViewModel> Get(long id);
        ServiceResult<IEnumerable<ServiceViewModel>> GetAll();
    }
}