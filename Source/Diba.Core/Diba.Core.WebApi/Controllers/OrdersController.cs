using Diba.Core.AppService.Contract;
using Microsoft.AspNetCore.Mvc;
using Diba.Core.WebApi.Internal;
using Diba.Core.AppService.Contract.Order;
using Microsoft.AspNetCore.Authorization;

namespace Diba.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersCommandService _ordersCommandService;

        public OrdersController(IOrdersCommandService ordersCommandService)
        {
            _ordersCommandService = ordersCommandService;
        }

        [AllowAnonymous]
        [Scope("addUser")]
        [HttpPost]
        public ServiceResult<OrderViewModel> Create(CreateOrderInputModel model)
        {
            ServiceResult<OrderViewModel> response = _ordersCommandService.Create(model);
            return response;
        }
    }
}