using System.Collections.Generic;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diba.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        public ServiceController(IServiceQueryService serviceQueryService, IServiceCommandService serviceCommandService)
        {
            _serviceQueryService = serviceQueryService;
            _serviceCommandService = serviceCommandService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        public ServiceResult<ServiceViewModel> Get(int id)
        {
            ServiceResult<ServiceViewModel> service = _serviceQueryService.Get(id);
            return service;
        }

        [HttpGet]
        [AllowAnonymous]
        public ServiceResult<IEnumerable<ServiceViewModel>> GetList()
        {
            ServiceResult<IEnumerable<ServiceViewModel>> services = _serviceQueryService.GetAll();
            return services;
        }

        [HttpPost]
        [AllowAnonymous]
        public ServiceResult<ServiceViewModel> Create(CreateServiceInputModel model)
        {
            return _serviceCommandService.Create(model);
        }

        [HttpPatch]
        [AllowAnonymous]
        [Route("{id}")]
        public ServiceResult<ServiceViewModel> Update(long id, UpdateServiceInputModel model)
        {
            return _serviceCommandService.Update(id, model);
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("{id}")]
        public ServiceResult<ServiceViewModel> Delete(long id)
        {
            return _serviceCommandService.Delete(id);
        }

        private readonly IServiceCommandService _serviceCommandService;
        private readonly IServiceQueryService _serviceQueryService;
    }
}