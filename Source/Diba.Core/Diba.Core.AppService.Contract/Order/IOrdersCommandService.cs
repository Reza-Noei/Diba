using Diba.Core.AppService.Contract;

namespace Diba.Core.AppService.Contract
{
    public interface IOrdersCommandService
    {
        ServiceResult<OrderViewModel> Create(CreateOrderInputModel request);

        ServiceResult<OrderViewModel> Update(int id, UpdateOrderInputModel request);

        ServiceResult<OrderViewModel> Delete(int id);

        ServiceResult<RequestItemViewModel> AddItem(int id, CreateOrderRequestItemInputModel model);

        ServiceResult<RequestItemViewModel> DeleteItem(int id, int itemId);
    }
}