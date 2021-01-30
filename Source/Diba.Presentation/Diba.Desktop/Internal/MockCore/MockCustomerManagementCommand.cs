using Diba.Core.AppService;
using Diba.Core.AppService.Contract;

namespace Diba.Desktop.Internal.DibaCore
{
    internal class MockCustomerManagementCommand : ICustomerManagementCommand
    {
        public ServiceResult<CustomerViewModel> Create(CreateCustomerInputModel request)
        {
            return new ServiceResult<CustomerViewModel>()
            {
                StatusCode = StatusCode.Created,
                Data = new CustomerViewModel()
                {
                    Id = 1,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Address = request.ContactInfo.Address,
                    Code = request.Code,
                    District = request.District,
                    EconomicCode = request.EconomicCode,
                    NationalIdentifier = request.NationalIdentifier,
                    RegistrationNumber = request.RegistrationNumber,
                    PhoneNumber = request.ContactInfo.PhoneNumber,
                    PostalCode = request.PostalCode                    
                }
            };
        }
    }
}
