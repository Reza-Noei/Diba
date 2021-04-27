using Diba.Core.AppService.Contract;

namespace Diba.Core.AppService.Contract
{
    public interface IOrdersCommandService
    {
        ServiceResult<OrderViewModel> Create(CreateOrderInputModel request);

        ServiceResult<OrderViewModel> Update(UpdateOrderInputModel request);

        ServiceResult<OrderViewModel> Delete(long id);

        ServiceResult<OrderItemsViewModel> UpdateOrderItems(UpdateOrderItemsInputModel request);

        ServiceResult<OrderViewModel> Collect(long id);

        ServiceResult<OrderViewModel> Calculate(long id);

        ServiceResult<OrderViewModel> Process(long id);

        ServiceResult<OrderViewModel> Deliver(long id);

        ServiceResult<OrderViewModel> Balance(long id);
    }
}