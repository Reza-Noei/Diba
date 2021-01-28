using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Product;
using Diba.Core.AppService.Contract.Product.Model.InputModels;
using Diba.Core.AppService.Contract.Product.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Diba.Core.WebApi.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(IProductQueryService productQueryService, IProductCommandService productCommandService)
        {
            _productQueryService = productQueryService;
            _productCommandService = productCommandService;
        }

        //GET 
        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        public ServiceResult<ProductViewModel> Get(int id)
        {
            ServiceResult<ProductViewModel> product = _productQueryService.Get(id);
            return product;
        }

        [HttpGet]
        [AllowAnonymous]
        public ServiceResult<IEnumerable<ProductViewModel>> GetList()
        {
            ServiceResult<IEnumerable<ProductViewModel>> products = _productQueryService.GetList();
            return products;
        }

        [HttpPost]
        [AllowAnonymous]
        public ServiceResult<ProductViewModel> Create(CreateProductViewModel model)
        {
            return _productCommandService.Create(model);
        }

        [HttpPatch]
        [AllowAnonymous]
        [Route("{id}")]
        public ServiceResult<ProductViewModel> Update(int id, UpdateProductViewModel model)
        {
            return _productCommandService.Update(id, model);
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("{id}")]
        public ServiceResult<ProductViewModel> Delete(int id)
        {
            return _productCommandService.Delete(id);
        }

        private readonly IProductCommandService _productCommandService;
        private readonly IProductQueryService _productQueryService;
    }
}