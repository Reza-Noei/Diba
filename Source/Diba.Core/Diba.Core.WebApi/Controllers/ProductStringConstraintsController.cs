using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.ProductConstraint;
using Diba.Core.AppService.Contract.ProductConstraint.Model.ViewModel;
using Diba.Core.AppService.Contract.ProductStringConstraint.Model.InputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diba.Core.WebApi.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductStringConstraintsController : ControllerBase
    {
        public ProductStringConstraintsController(IProductStringConstraintsQueryService productStringConstraintsQueryService,
            IProductStringConstraintsCommandService productStringConstraintsCommandService)
        {
            _productStringConstraintsQueryService = productStringConstraintsQueryService;
            _productStringConstraintsCommandService = productStringConstraintsCommandService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id}/StringConstraints")]
        public ServiceResult<ProductStringConstraintsViewModel> Get(int id)
        {
            ServiceResult<ProductStringConstraintsViewModel> product = _productStringConstraintsQueryService.Get(id);
            return product;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("{id}/StringConstraints")]
        public ServiceResult<ProductStringConstraintsViewModel> Create(int id , CreateProductStringConstraintsViewModel model)
        {
            return _productStringConstraintsCommandService.Create(id, model);
        }

        [HttpPatch]
        [AllowAnonymous]
        [Route("{productId}/StringConstraints/{constraintId}")]
        public ServiceResult<ProductStringConstraintsViewModel> Update(int productId, int constraintId, UpdateProductStringConstraintsViewModel model)
        {
            return _productStringConstraintsCommandService.Update(productId, constraintId, model);
        }

        [HttpDelete]
        [AllowAnonymous]

        [Route("{productId}/StringConstraints/{constraintId}")]
        public ServiceResult<ProductStringConstraintsViewModel> Delete(int id)
        {
            return _productStringConstraintsCommandService.Delete(id);
        }

        private readonly IProductStringConstraintsCommandService _productStringConstraintsCommandService;
        private readonly IProductStringConstraintsQueryService _productStringConstraintsQueryService;
    }
}
