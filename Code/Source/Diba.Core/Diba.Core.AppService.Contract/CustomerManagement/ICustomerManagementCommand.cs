namespace Diba.Core.AppService.Contract
{
    public interface ICustomerManagementCommand
    {
        ServiceResult<CustomerViewModel> Create(CreateCustomerInputModel request);
    }
}
