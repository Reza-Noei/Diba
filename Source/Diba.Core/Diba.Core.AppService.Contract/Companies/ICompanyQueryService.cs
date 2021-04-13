using System.Collections.Generic;

namespace Diba.Core.AppService.Contract.Companies
{
    public interface ICompanyQueryService
    {
        ServiceResult<CompanyViewModel> Get(long id);
        ServiceResult<IEnumerable<CompanyViewModel>> GetAll();
    }
}