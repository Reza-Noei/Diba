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
            };
        }
    }
}
