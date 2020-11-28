using Diba.Core.AppService.Contract;
using System.Collections.Generic;

namespace Diba.Desktop.Internal.DibaCore
{
    internal class MockCustomerManagementQuery : ICustomerManagementQuery
    {
        public ServiceResult<IEnumerable<CustomerViewModel>> Search(CustomerSearchInputModel request)
        {
            return new ServiceResult<IEnumerable<CustomerViewModel>>(StatusCode.Ok)
            {
                Data = new List<CustomerViewModel>()
                {
                    new CustomerViewModel()
                    {
                        Id = 1,
                        Address = "تهران - اسلامشهر - واوان - بلوار هشت بهشت - خیابان جوادی - کوچه 12 - پلاک 1",
                        Code = "935-44263",
                        District = "اسلامشهر",
                        EconomicCode = "11202225",
                        FirstName = "یاسر",
                        LastName = "میرزایی",
                        NationalIdentifier = "11020-3654214",
                        PhoneNumber = "09357277842",
                        PostalCode = "33179-52635",
                        RegistrationNumber = "11021025745",
                    },
                    new CustomerViewModel()
                    {
                        Id = 2,
                        Address = "تهران - محله صادقیه - سه راه تهران ویلا - بن بست قاسمی - پلاک 13",
                        Code = "935-5525563",
                        District = "ستارخان",
                        EconomicCode = "52555254",
                        FirstName = "احمد",
                        LastName = "رجبی",
                        NationalIdentifier = "46657-3654214",
                        PhoneNumber = "09357277758",
                        PostalCode = "1417-48966",
                        RegistrationNumber = "11241421512",
                    },
                    new CustomerViewModel()
                    {
                        Id = 3,
                        Address = "تهران - ونک - خیابان برزیل - بعد از توانیر - پلاک 9",
                        Code = "935-4654",
                        District = "ونک",
                        EconomicCode = "4654613",
                        FirstName = "وحید",
                        LastName = "شیر محمدی",
                        NationalIdentifier = "13245-3654214",
                        PhoneNumber = "09125663645",
                        PostalCode = "1417-454218",
                        RegistrationNumber = "54644216541",
                    },
                    new CustomerViewModel()
                    {
                        Id = 4,
                        Address = "تهران - هفت تیر - خیابان خرمشهر - کوچه اقاقیا - پلاک 1 واحد 24",
                        Code = "935-4654",
                        District = "ونک",
                        EconomicCode = "4654613",
                        FirstName = "مهدی",
                        LastName = "رحیمیان",
                        NationalIdentifier = "45636-69854",
                        PhoneNumber = "09121142355",
                        PostalCode = "5497-46548",
                        RegistrationNumber = "49865312351",
                    },
                    new CustomerViewModel()
                    {
                        Id = 5,
                        Address = "تهران - خیابان بهشتی - نرسیده به سهروردی - خیابان احمد نجفی - پلاک 6",
                        Code = "935-4546",
                        District = "سهروردی",
                        EconomicCode = "6564641613",
                        FirstName = "مجتبی",
                        LastName = "گودرزی",
                        NationalIdentifier = "4561-45645",
                        PhoneNumber = "09124561324",
                        PostalCode = "5451-45461",
                        RegistrationNumber = "4564125645",
                    }
                }
            };
        }
    }
}
