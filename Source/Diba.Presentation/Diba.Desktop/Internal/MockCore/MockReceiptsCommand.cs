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
                    ReceptionDate = DateTime.Now.AddDays(-10),
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
                    ReceptionDate = DateTime.Now.AddDays(-100),
                    CollectingDueDate = DateTime.Now.AddDays(5),
                    CustomerFullName = "جمشید هاشم پور",
                    SecretaryFullName = "رضا سلطانی",
                    CollectorFullName = "محمد علیپور",
                    DeliveringDueDate = DateTime.Now.AddDays(30),
                    DeliveryFullName = "محمد علیپور",
                    State = ReceiptState.Submitted,
                    Items = new List<ReceiptItemViewModel>()
                    {
                        new ReceiptItemViewModel()
                        {
                            Description = "فرش دستباف ابریشمی 12 متری"
                        },
                        new ReceiptItemViewModel()
                        {
                            Description = "2 قطعه موکت 6 متری نخی"
                        }
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
                        ReceptionDate = DateTime.Now.AddDays(-50),
                        CustomerFullName = "کاظم محمود زاده",
                        SecretaryFullName = "شیوا بیگلو",
                        State = ReceiptState.Submitted,
                        Items = new List<ReceiptItemViewModel>()
                        {
                            new ReceiptItemViewModel()
                            {
                                Description = "فرش ماشینی 12 متری"
                            },
                            new ReceiptItemViewModel()
                            {
                                Description = "فرش دستباف پشمی 6 متری"
                            },
                            new ReceiptItemViewModel()
                            {
                                Description = "دو قطعه فرش دستباف پشمی 12 متری"
                            }
                        }
                    },
                    new ReceiptViewModel()
                    {
                        Id = 2,
                        ReceptionDate = DateTime.Now.AddDays(-30),
                        CustomerFullName = "جواد اکبری",
                        SecretaryFullName = "شیوا بیگلو",
                        State = ReceiptState.Collected,
                        CollectingDueDate = DateTime.Now.AddDays(-5),
                        CollectorFullName = "جعفر قرایی",
                        DeliveringDueDate = DateTime.Now.AddDays(5),
                        DeliveryFullName = "محسن کریمی",
                        Items = new List<ReceiptItemViewModel>()
                        {
                            new ReceiptItemViewModel()
                            {
                                Description = "فرش ماشینی 6 متری"
                            },
                            new ReceiptItemViewModel()
                            {
                                Description = "موکت پشمی 6 متری"
                            },
                            new ReceiptItemViewModel()
                            {
                                Description = "دو قطعه فرش دستباف پشمی 12 متری"
                            }
                        }
                    },
                    new ReceiptViewModel()
                    {
                        Id = 3,
                        ReceptionDate = DateTime.Now.AddDays(-1),
                        CustomerFullName = "مهران میرزرگر",
                        SecretaryFullName = "شیوا بیگلو",
                        State = ReceiptState.Submitted,
                        Items = new List<ReceiptItemViewModel>()
                        {
                            new ReceiptItemViewModel()
                            {
                                Description = "فرش ماشینی 18 متری"
                            },
                            new ReceiptItemViewModel()
                            {
                                Description = "موکت پلاستیک 12 متری"
                            }
                        }
                    },
                    new ReceiptViewModel()
                    {
                        Id = 4,
                        ReceptionDate = DateTime.Now.AddDays(-15),
                        CustomerFullName = "ابراهیم قاسمی اقدم",
                        SecretaryFullName = "شهریار سرمست",
                        State = ReceiptState.Delivered,
                        CollectingDueDate = DateTime.Now.AddDays(-20),
                        CollectorFullName = "سلیمان نجاتی",
                        DeliveringDueDate = DateTime.Now.AddDays(-5),
                        DeliveryFullName = "محسن کریمی",
                        Items = new List<ReceiptItemViewModel>()
                        {
                            new ReceiptItemViewModel()
                            {
                                Description = "فرش صادراتی 6 متری"
                            },
                            new ReceiptItemViewModel()
                            {
                                Description = "موکت 8 متری"
                            },
                            new ReceiptItemViewModel()
                            {
                                Description = "دو قطعه فرش 12 متری"
                            }
                        }
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
