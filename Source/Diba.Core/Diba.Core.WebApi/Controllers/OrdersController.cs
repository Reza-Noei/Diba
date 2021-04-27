using System;
using Diba.Core.AppService.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace Diba.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersCommandService _ordersCommandService;
        private readonly IOrdersQueryService _ordersQueryService;

        public OrdersController(IOrdersCommandService ordersCommandService, IOrdersQueryService ordersQueryService)
        {
            _ordersCommandService = ordersCommandService;
            _ordersQueryService = ordersQueryService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{id}")]
        public ServiceResult<OrderViewModel> Get(int id)
        {
            ServiceResult<OrderViewModel> response = _ordersQueryService.Get(id);
            return response;
        }

        [AllowAnonymous]
        [HttpGet]
        public ServiceResult<IList<OrderViewModel>> GetAll()
        {
            ServiceResult<IList<OrderViewModel>> response = _ordersQueryService.GetAll();
            return response;
        }

        [AllowAnonymous]
        [HttpPost]
        public ServiceResult<OrderViewModel> Create(CreateOrderInputModel model)
        {
            ServiceResult<OrderViewModel> response = _ordersCommandService.Create(model);
            return response;
        }

        [AllowAnonymous]
        [HttpPatch]
        [Route("{id}")]
        public ServiceResult<OrderViewModel> Update(long id, UpdateOrderInputModel command)
        {
            command.Id = id;
            ServiceResult<OrderViewModel> response = _ordersCommandService.Update(command);
            return response;
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("{id}")]
        public ServiceResult<OrderViewModel> Delete(long id)
        {
            ServiceResult<OrderViewModel> response = _ordersCommandService.Delete(id);
            return response;
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("{id}/item")]
        public ServiceResult<OrderItemsViewModel> UpdateOrderItems(long id, UpdateOrderItemsInputModel command)
        {
            command.OrderId = id;

            ServiceResult<OrderItemsViewModel> response = _ordersCommandService.UpdateOrderItems(command);
            return response;
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("{id}/status")]
        public ServiceResult<OrderViewModel> UpdateStatus(long id, int value)
        {
            //TODO:Refactor this

            ServiceResult<OrderViewModel> response = null;

            var state = (OrderStatesEnum)value;

            switch (state)
            {
                case OrderStatesEnum.Collected:
                    response = _ordersCommandService.Collect(id);
                    break;

                case OrderStatesEnum.Calculated:
                    response = _ordersCommandService.Calculate(id);
                    break;

                case OrderStatesEnum.Processed:
                    response = _ordersCommandService.Process(id);
                    break;

                case OrderStatesEnum.Deliverd:
                    response = _ordersCommandService.Deliver(id);
                    break;

                case OrderStatesEnum.Balanaced:
                    response = _ordersCommandService.Balance(id);
                    break;
            }

            return response;
        }
    }
}