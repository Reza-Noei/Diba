using System;
using System.Collections.Generic;
using Diba.Core.AppService.Contract;

namespace Diba.Desktop.Internal.DibaCore
{
    internal class MockReceiptsCommand : IReceiptsCommand
    {
        public ServiceResult<ReceiptViewModel> Create(ReceiptInputModel model)
        {
            return new ServiceResult<ReceiptViewModel>(StatusCode.Created)
            {
                Data = new ReceiptViewModel()
                {
                    Id = 1,
                    State = ReceiptState.Submitted,
                    CustomerFullName = "محسن عباسی",
                    SecretaryFullName = "احمد رضا معصومی"
                }
            };
        }
    }

    internal class MockReceiptsQuery : IReceiptsQuery
    {
        public ServiceResult<ReceiptViewModel> Get(long Id)
        {
            return new ServiceResult<ReceiptViewModel>()
            {
                Data = new ReceiptViewModel()
                {
                    Id = 1,
                    CollectingDueDate = DateTime.Now.AddDays(5),
                    CustomerFullName = "جمشید هاشم پور",
                    SecretaryFullName = "رضا سلطانی",
                    CollectorFullName = "محمد علیپور",
                    DeliveringDueDate = DateTime.Now.AddDays(30),
                    DeliveryFullName = "محمد علیپور",
                    State = ReceiptState.Submitted,                    
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
                        CustomerFullName = "کاظم محمود زاده",
                        SecretaryFullName = "شیوا بیگلو",
                        State = ReceiptState.Submitted,
                        
                    },
                    new ReceiptViewModel()
                    {
                        Id = 2,
                        CustomerFullName = "جواد اکبری",
                        SecretaryFullName = "شیوا بیگلو",
                        State = ReceiptState.Collected,
                        CollectingDueDate = DateTime.Now.AddDays(-5),
                        CollectorFullName = "جعفر قرایی",
                        DeliveringDueDate = DateTime.Now.AddDays(5),
                        DeliveryFullName = "محسن کریمی"
                    },
                    new ReceiptViewModel()
                    {
                        Id = 3,
                        CustomerFullName = "مهران میرزرگر",
                        SecretaryFullName = "شیوا بیگلو",
                        State = ReceiptState.Submitted
                    },
                    new ReceiptViewModel()
                    {
                        Id = 4,
                        CustomerFullName = "ابراهیم قاسمی اقدم",
                        SecretaryFullName = "شهریار سرمست",
                        State = ReceiptState.Delivered,
                        CollectingDueDate = DateTime.Now.AddDays(-20),
                        CollectorFullName = "سلیمان نجاتی",
                        DeliveringDueDate = DateTime.Now.AddDays(-5),
                        DeliveryFullName = "محسن کریمی"
                    }
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
                        Description = "2 عدد فرش 6 متری ماشینی" 
                    },
                    new ReceiptItemViewModel()
                    {
                        Description = "1 عدد فرش 12 متری دست باف"
                    }
                }
            };
        }
    }
}
