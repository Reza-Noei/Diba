using Diba.Core.AppService.Contract.Order;

namespace Diba.Core.AppService.Contract
{
    public interface IOrdersCommandService
    {
        ServiceResult<OrderViewModel> Create(CreateOrderInputModel request);
    }
}