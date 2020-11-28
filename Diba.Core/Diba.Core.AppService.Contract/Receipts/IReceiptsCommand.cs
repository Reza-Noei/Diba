using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Contract
{
    public interface IReceiptsCommand
    {
        ServiceResult<ReceiptViewModel> Create(ReceiptInputModel model);
    }
}
