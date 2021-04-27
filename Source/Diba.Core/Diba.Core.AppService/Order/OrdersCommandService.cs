using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;


namespace Diba.Core.AppService
{
    public class OrdersCommandService : IOrdersCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrdersCommandService(IOrderRepository orderRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ServiceResult<OrderViewModel> Create(CreateOrderInputModel request)
        {
            var order = Domain.Order.Create(request.CustomerId, Request.Create(request.RequestItems,request.AnnouncedPrice),CollectionInfo.Create(request.CollectorId,request.CollectionDate,request.CollectionLocation),DeliveryInfo.Create(request.DelivelerId,request.DeliveryDate,request.DeliveryLocation));

            _orderRepository.Add(order);
            _unitOfWork.Commit();

            return new ServiceResult<OrderViewModel>(_mapper.Map<OrderViewModel>(order));
        }

        public ServiceResult<OrderViewModel> Update(UpdateOrderInputModel request)
        {
            Domain.Order order = _orderRepository.GetById(request.Id);

            if (order == null)
                return new ServiceResult<OrderViewModel>(StatusCode.NotFound);

            order.Update(request.CustomerId, Request.Create(request.Items, request.AnnouncedPrice), CollectionInfo.Create(request.CollectorId, request.CollectionDate, request.CollectionLocation), DeliveryInfo.Create(request.DelivelerId, request.DeliveryDate, request.DeliveryLocation));
            
            _unitOfWork.Commit();

            return new ServiceResult<OrderViewModel>(_mapper.Map<OrderViewModel>(order));
        }

        public ServiceResult<OrderViewModel> Delete(long id)
        {
            Domain.Order order = _orderRepository.GetById(id);

            if (order == null)
                return new ServiceResult<OrderViewModel>(StatusCode.NotFound);

            _orderRepository.Delete(order);
            _unitOfWork.Commit();

            return new ServiceResult<OrderViewModel>(_mapper.Map<OrderViewModel>(order));
        }

        public ServiceResult<OrderItemsViewModel> UpdateOrderItems(UpdateOrderItemsInputModel request)
        {
            Domain.Order order = _orderRepository.GetById(request.OrderId);

            if (order == null)
                return new ServiceResult<OrderItemsViewModel>(StatusCode.NotFound);

            var orderItem = _mapper.Map<IEnumerable<OrderItem>>(request.OrderItems).ToList();

            order.UpdateItems(orderItem);
            _unitOfWork.Commit();

          return new ServiceResult<OrderItemsViewModel>((_mapper.Map<OrderItemsViewModel>(orderItem)));
        }

        public ServiceResult<OrderViewModel> Collect(long id)
        {
            Domain.Order order = _orderRepository.GetById(id);

            if (order == null)
                return new ServiceResult<OrderViewModel>(StatusCode.NotFound);

            order.Collect();
            _unitOfWork.Commit();

            return new ServiceResult<OrderViewModel>(_mapper.Map<OrderViewModel>(order));
        }

        public ServiceResult<OrderViewModel> Calculate(long id)
        {
            Domain.Order order = _orderRepository.GetById(id);

            if (order == null)
                return new ServiceResult<OrderViewModel>(StatusCode.NotFound);

            order.Calculate();
            _unitOfWork.Commit();

            return new ServiceResult<OrderViewModel>(_mapper.Map<OrderViewModel>(order));
        }

        public ServiceResult<OrderViewModel> Process(long id)
        {
            Domain.Order order = _orderRepository.GetById(id);

            if (order == null)
                return new ServiceResult<OrderViewModel>(StatusCode.NotFound);

            order.Process();
            _unitOfWork.Commit();

            return new ServiceResult<OrderViewModel>(_mapper.Map<OrderViewModel>(order));
        }

        public ServiceResult<OrderViewModel> Deliver(long id)
        {
            Domain.Order order = _orderRepository.GetById(id);

            if (order == null)
                return new ServiceResult<OrderViewModel>(StatusCode.NotFound);

            order.Deliver();
            _unitOfWork.Commit();

            return new ServiceResult<OrderViewModel>(_mapper.Map<OrderViewModel>(order));
        }

        public ServiceResult<OrderViewModel> Balance(long id)
        {
            Domain.Order order = _orderRepository.GetById(id);

            if (order == null)
                return new ServiceResult<OrderViewModel>(StatusCode.NotFound);

            order.Balance();
            _unitOfWork.Commit();

            return new ServiceResult<OrderViewModel>(_mapper.Map<OrderViewModel>(order));
        }
    }
}