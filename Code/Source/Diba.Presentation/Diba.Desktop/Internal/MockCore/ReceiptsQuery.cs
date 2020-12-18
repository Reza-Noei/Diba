using Diba.Core.AppService.Contract;
using System;
using System.Collections.Generic;

namespace Diba.Desktop.Internal.DibaCore
{
    internal class ReceiptsQuery : IReceiptsQuery
    {
        public ServiceResult<ReceiptViewModel> Get(long Id)
        {
            return new ServiceResult<ReceiptViewModel>(StatusCode.Ok)
            {
                Data = new ReceiptViewModel()
                {
                    CollectingDueDate = null,
                    CollectorFullName = "رضا نوعی",
                    CustomerFullName = "احمد رجبی",
                    DeliveryFullName = "قاسم سلیمانی",
                    DeliveringDueDate = DateTime.Now.AddDays(-10),
                    SecretaryFullName = "احمد کاظمی",
                    State = ReceiptState.Delivered,
                    Id = 1
                }
            };
        }

        public ServiceResult<IEnumerable<ReceiptItemViewModel>> GetItems(long Id)
        {
            return new ServiceResult<IEnumerable<ReceiptItemViewModel>>(StatusCode.Ok)
            {
                Data = new List<ReceiptItemViewModel>()
                {
                    new ReceiptItemViewModel()
                    {
                        Description = " 2 عدد فرش دستباف6 متری",
                    },
                    new ReceiptItemViewModel()
                    {
                        Description = " 1 عدد فرش ماشینی 12 متری",
                    },
                    new ReceiptItemViewModel()
                    {
                        Description = "1 عدد قالی 5 متری ابریشمی",
                    },
                    new ReceiptItemViewModel()
                    {
                        Description = " 5 عدد فرش ماشینی 6 متری",
                    }
                }
            };
        }

        public ServiceResult<IEnumerable<ReceiptViewModel>> GetList(ReceiptsQueryInputModel request)
        {
            return new ServiceResult<IEnumerable<ReceiptViewModel>>(StatusCode.Ok)
            {
                Data = new List<ReceiptViewModel>()
                {
                    new ReceiptViewModel()
                    {
                        Id = 1,
                        CollectingDueDate = DateTime.Now.AddDays(-10),
                        DeliveringDueDate = DateTime.Now.AddDays(-1),
                        CollectorFullName = "رضا نوعی",
                        CustomerFullName = "احمد رجبی",
                        DeliveryFullName = "رضا نوعی",
                        SecretaryFullName = "آرش کاظمی",
                        State = ReceiptState.Delivered
                    },
                    new ReceiptViewModel()
                    {
                        Id = 2,
                        CollectingDueDate = null,
                        DeliveringDueDate = null,
                        CollectorFullName = "رضا بهرامی",
                        CustomerFullName = "مرتضی افشار",
                        DeliveryFullName = "رضا بهرامی",
                        SecretaryFullName = "آرش کاظمی",
                        State = ReceiptState.Submitted
                    },
                    new ReceiptViewModel()
                    {
                        Id = 3,
                        CollectingDueDate = null,
                        DeliveringDueDate = null,
                        CollectorFullName = "علی حسینی",
                        CustomerFullName = "اصغر حیدیری",
                        DeliveryFullName = "رضا بهرامی",
                        SecretaryFullName = "آرش کاظمی",
                        State = ReceiptState.Submitted
                    }
                }
            };
        }
    }
}
