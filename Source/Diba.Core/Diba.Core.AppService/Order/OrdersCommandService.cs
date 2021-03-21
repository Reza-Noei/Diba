using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Order;
using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using System.Collections.Generic;

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
            List<Domain.RequestItem> items = _mapper.Map<List<Domain.RequestItem>>(request.RequestItems);

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

            _orderRepositiry.Add(order);
            _unitOfWork.Commit();

            return new ServiceResult<OrderViewModel>(_mapper.Map<OrderViewModel>(order));
        }
    }
}
