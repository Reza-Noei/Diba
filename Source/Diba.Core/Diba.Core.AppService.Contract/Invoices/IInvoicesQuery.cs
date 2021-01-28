using System.Collections.Generic;

namespace Diba.Core.AppService.Contract
{
    public interface IInvoicesQuery
    {
        ServiceResult<InvoiceShortViewModel> Get(long id);
        ServiceResult<IEnumerable<InvoiceShortViewModel>> List(QueryInvoicesInputModel request);
        ServiceResult<IEnumerable<InvoiceShortViewModel>> GetByCustomerId(long customerId);
    }
}
