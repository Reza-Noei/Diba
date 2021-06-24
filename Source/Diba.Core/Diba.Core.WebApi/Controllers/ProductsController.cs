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
    public class ProductsController : ControllerBase
    {
        public ProductsController(IProductQueryService productQueryService, IProductCommandService productCommandService)
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
        [Route("/Final")]
        public ServiceResult<ProductViewModel> CreateFinal(CreateFinalProductViewModel model)
        {
            return _productCommandService.CreateFinalProduct(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/Generic")]

        public ServiceResult<ProductViewModel> CreateGeneric(CreateGenericProductViewModel command)
        {
            return _productCommandService.CreateGenericProduct(command);
        }

        [HttpPatch]
        [AllowAnonymous]
        [Route("{id}/Final")]
        public ServiceResult<ProductViewModel> UpdateFinal(int id, UpdateFinalProductViewModel command)
        {
            command.ProductId = id;
            return _productCommandService.UpdateFinalProduct(command);
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("{id}/Generic")]
        public ServiceResult<ProductViewModel> UpdateGeneric(int id, UpdateGenericProductViewModel model)
        {
            model.ProductId = id;

            ServiceResult<ProductViewModel> response = _productCommandService.UpdateGenericProduct(model);
            return response;
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