using Diba.Core.AppService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diba.Desktop.Internal.DibaCore
{
    public class MockInvoicesQuery : IInvoicesQuery
    {
        public ServiceResult<InvoiceShortViewModel> Get(long id)
        {
            return new ServiceResult<InvoiceShortViewModel>()
            {
                Data = new InvoiceShortViewModel()
                {
                    Id = 1,
                    Creation = DateTime.UtcNow.AddDays(-20),
                    Customer = "احمد تقی زاده",
                    InvoiceNumber = "1101120",
                    Secretary = "مهران موسوی"
                }
            };
        }

        public ServiceResult<IEnumerable<InvoiceShortViewModel>> GetByCustomerId(long customerId)
        {
            return new ServiceResult<IEnumerable<InvoiceShortViewModel>>()
            {
                Data = new List<InvoiceShortViewModel>()
                {
                    new InvoiceShortViewModel()
                    {
                        Id = 1,
                        Creation = DateTime.UtcNow.AddDays(-20),
                        Customer = "احمد تقی زاده",
                        InvoiceNumber = "1101120",
                        Secretary = "مهران موسوی"
                    },
                    new InvoiceShortViewModel()
                    {
                        Id = 2,
                        Creation = DateTime.UtcNow.AddDays(-26),
                        Customer = "احمد تقی زاده",
                        InvoiceNumber = "1101160",
                        Secretary = "مهران موسوی"
                    },
                    new InvoiceShortViewModel()
                    {
                        Id = 5,
                        Creation = DateTime.UtcNow.AddDays(-126),
                        Customer = "احمد تقی زاده",
                        InvoiceNumber = "1101170",
                        Secretary = "مهران موسوی"
                    }
                }
            };
        }

        public ServiceResult<IEnumerable<InvoiceShortViewModel>> List(QueryInvoicesInputModel request)
        {
            throw new NotImplementedException();
        }
    }
}
