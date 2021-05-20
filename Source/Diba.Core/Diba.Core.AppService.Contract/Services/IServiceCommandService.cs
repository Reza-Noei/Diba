namespace Diba.Core.AppService.Contract.Services
{
    public interface IServiceCommandService
    {
        ServiceResult<ServiceViewModel> Create(CreateServiceInputModel request);

        ServiceResult<ServiceViewModel> Update(long id, UpdateServiceInputModel request);

        ServiceResult<ServiceViewModel> Delete(long id);
    }
}