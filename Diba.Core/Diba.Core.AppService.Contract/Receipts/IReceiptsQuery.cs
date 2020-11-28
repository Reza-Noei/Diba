using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Contract
{
    public interface IReceiptsQuery
    {
        ServiceResult<ReceiptViewModel> Get(long Id);

        ServiceResult<IEnumerable<ReceiptItemViewModel>> GetItems(long Id);

        ServiceResult<IEnumerable<ReceiptViewModel>> GetList(ReceiptsQueryInputModel request);
    }
}
