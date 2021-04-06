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
        public ServiceResult<OrderViewModel> Update(int id, UpdateOrderInputModel model)
        {
            ServiceResult<OrderViewModel> response = _ordersCommandService.Update(id, model);
            return response;
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("{id}")]
        public ServiceResult<OrderViewModel> Delete(int id)
        {
            ServiceResult<OrderViewModel> response = _ordersCommandService.Delete(id);
            return response;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("{id}/item")]
        public ServiceResult<RequestItemViewModel> AddItem(int id, CreateOrderRequestItemInputModel model)
        {
            ServiceResult<RequestItemViewModel> response = _ordersCommandService.AddItem(id, model);
            return response;
        }   
        
        [AllowAnonymous]
        [HttpDelete]
        [Route("{id}/item/{itemId}")]
        public ServiceResult<RequestItemViewModel> DeleteItem(int id, int itemId)
        {
            ServiceResult<RequestItemViewModel> response = _ordersCommandService.DeleteItem(id, itemId);
            return response;
        }
    }
}