using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.Data.Repository.Interfaces;
using System.Collections.Generic;

namespace Diba.Core.AppService
{
    public class OrdersQueryService : IOrdersQueryService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepositiry;

        public OrdersQueryService(IMapper mapper, IOrderRepository orderRepositiry)
        {
            _mapper = mapper;
            _orderRepositiry = orderRepositiry;
        }

        public ServiceResult<OrderViewModel> Get(int id)
        {
            Domain.Order order = _orderRepositiry.GetById(id);

            return new ServiceResult<OrderViewModel>(_mapper.Map<OrderViewModel>(order));
        }

        public ServiceResult<IList<OrderViewModel>> GetAll()
        {
            IEnumerable<Domain.Order> orders = _orderRepositiry.GetAll();

            return new ServiceResult<IList<OrderViewModel>>(_mapper.Map<IList<OrderViewModel>>(orders));
        }
    }
}