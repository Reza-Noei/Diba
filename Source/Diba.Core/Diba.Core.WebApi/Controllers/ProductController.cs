using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Product;
using Diba.Core.AppService.Contract.Product.Model.InputModels;
using Diba.Core.AppService.Contract.Product.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diba.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {

        }

        [HttpPost]
        [AllowAnonymous]
        public ServiceResult<ProductViewModel> Create(CreateProductViewModel model)
        {
            //return _constraintCommandService.Create(model);
            throw new System.Exception();

        }

        private readonly IProductCommandService _productCommandService;
        private readonly IProductQueryService _productQueryService;
    }
}
