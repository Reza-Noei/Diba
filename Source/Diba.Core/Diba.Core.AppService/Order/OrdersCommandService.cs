using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Diba.Core.AppService
{
    public class OrdersCommandService : IOrdersCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepositiry;

        public OrdersCommandService(IOrderRepository orderRepositiry, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _orderRepositiry = orderRepositiry;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ServiceResult<OrderViewModel> Create(CreateOrderInputModel request)
        {
            var items = _mapper.Map<List<Domain.RequestItem>>(request.RequestItems);

            var order = new Domain.Order(request.CustomerId, items);

            _orderRepositiry.Add(order);
            _unitOfWork.Commit();

            return new ServiceResult<OrderViewModel>(_mapper.Map<OrderViewModel>(order));
        }

        public ServiceResult<OrderViewModel> Update(int id, UpdateOrderInputModel request)
        {
            Domain.Order order = _orderRepositiry.GetById(id);

            if (order == null)
                return new ServiceResult<OrderViewModel>(StatusCode.NotFound);

            //todo

            _orderRepositiry.Update(order);
            _unitOfWork.Commit();

            return new ServiceResult<OrderViewModel>(_mapper.Map<OrderViewModel>(order));
        }

        public ServiceResult<OrderViewModel> Delete(int id)
        {
            Domain.Order order = _orderRepositiry.GetById(id);

            if (order == null)
                return new ServiceResult<OrderViewModel>(StatusCode.NotFound);

            _orderRepositiry.Delete(order);
            _unitOfWork.Commit();

            return new ServiceResult<OrderViewModel>(_mapper.Map<OrderViewModel>(order));
        }

        public ServiceResult<RequestItemViewModel> AddItem(int id , CreateOrderRequestItemInputModel model)
        {
            Domain.Order order = _orderRepositiry.GetById(id);

            if (order == null)
                return new ServiceResult<RequestItemViewModel>(StatusCode.NotFound);

            var item = _mapper.Map<Domain.RequestItem>(model);

            order.AddItem(item);
            _unitOfWork.Commit();

            return new ServiceResult<RequestItemViewModel>(_mapper.Map<RequestItemViewModel>(item));
        }

        public ServiceResult<RequestItemViewModel> DeleteItem(int id, int itemId)
        {
            Domain.Order order = _orderRepositiry.GetById(id);

            if (order == null)
                return new ServiceResult<RequestItemViewModel>(StatusCode.NotFound);

            var item = order.RequestItems.FirstOrDefault(x => x.Id == itemId);

            if (item == null)
                return new ServiceResult<RequestItemViewModel>(StatusCode.NotFound);

            order.RequestItems.Remove(item);
            _unitOfWork.Commit();

            return new ServiceResult<RequestItemViewModel>(_mapper.Map<RequestItemViewModel>(item));
        }
    }
}