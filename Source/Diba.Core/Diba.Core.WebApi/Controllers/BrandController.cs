using Diba.Core.AppService.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Diba.Core.AppService.Contract.Brands;

namespace Diba.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        public BrandController(IBrandQueryService brandQueryService, IBrandCommandService BrandCommandService)
        {
            _brandQueryService = brandQueryService;
            _brandCommandService = BrandCommandService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        public ServiceResult<BrandViewModel> Get(int id)
        {
            ServiceResult<BrandViewModel> brand = _brandQueryService.Get(id);
            return brand;
        }

        [HttpGet]
        [AllowAnonymous]
        public ServiceResult<IEnumerable<BrandViewModel>> GetList()
        {
            ServiceResult<IEnumerable<BrandViewModel>> brands = _brandQueryService.GetAll();
            return brands;
        }

        [HttpPost]
        [AllowAnonymous]
        public ServiceResult<BrandViewModel> Create(CreateBrandInputModel model)
        {
            return _brandCommandService.Create(model);
        }

        [HttpPatch]
        [AllowAnonymous]
        [Route("{id}")]
        public ServiceResult<BrandViewModel> Update(long id, UpdateBrandInputModel model)
        {
            return _brandCommandService.Update(id, model);
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("{id}")]
        public ServiceResult<BrandViewModel> Delete(long id)
        {
            return _brandCommandService.Delete(id);
        }

        private readonly IBrandCommandService _brandCommandService;
        private readonly IBrandQueryService _brandQueryService;
    }
}