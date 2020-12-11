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
    public class ProductSelectiveConstraintsController : ControllerBase
    {
        public ProductSelectiveConstraintsController(IProductSelectiveConstraintsQueryService productSelectiveConstraintsQueryService,
            IProductSelectiveConstraintsCommandService productSelectiveConstraintsCommandService)
        {
            _productSelectiveConstraintsQueryService = productSelectiveConstraintsQueryService;
            _productSelectiveConstraintsCommandService = productSelectiveConstraintsCommandService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id}/SelectiveConstraints")]
        public ServiceResult<ProductSelectiveConstraintsViewModel> Get(int id)
        {
            ServiceResult<ProductSelectiveConstraintsViewModel> product = _productSelectiveConstraintsQueryService.Get(id);
            return product;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("{id}/SelectiveConstraints")]
        public ServiceResult<ProductSelectiveConstraintViewModel> Create(int id, CreateProductSelectiveConstraintsViewModel model)
        {
            return _productSelectiveConstraintsCommandService.Create(id, model);
        }

        [HttpPatch]
        [AllowAnonymous]
        [Route("{productId}/SelectiveConstraints/{constraintId}")]
        public ServiceResult<ProductSelectiveConstraintViewModel> Update(int productId, int constraintId, UpdateProductSelectiveConstraintsViewModel model)
        {
            return _productSelectiveConstraintsCommandService.Update(productId, constraintId, model);
        }

        [HttpDelete]
        [AllowAnonymous]

        [Route("{productId}/SelectiveConstraints/{constraintId}")]
        public ServiceResult<ProductSelectiveConstraintViewModel> Delete(int id)
        {
            return _productSelectiveConstraintsCommandService.Delete(id);
        }

        private readonly IProductSelectiveConstraintsCommandService _productSelectiveConstraintsCommandService;
        private readonly IProductSelectiveConstraintsQueryService _productSelectiveConstraintsQueryService;
    }
}
