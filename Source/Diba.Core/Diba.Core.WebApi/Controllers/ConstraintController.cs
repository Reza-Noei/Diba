using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Constraint;
using Diba.Core.AppService.Contract.Constraint.Model.InputModels;
using Diba.Core.AppService.Contract.Constraint.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Diba.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstraintController : ControllerBase
    {
        public ConstraintController(IConstraintCommandService constraintCommandService, IConstraintQueryService constraintQueryService)
        {
            _constraintCommandService = constraintCommandService;
            _constraintQueryService = constraintQueryService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/{id}")]
        public ServiceResult<ConstraintViewModel> Get(int id)
        {
            ServiceResult<ConstraintViewModel> product = _constraintQueryService.Get(id);
            return product;
        }

        [HttpGet]
        [AllowAnonymous]
        public ServiceResult<IEnumerable<ConstraintViewModel>> GetList()
        {
            ServiceResult<IEnumerable<ConstraintViewModel>> products = _constraintQueryService.GetList();
            return products;
        }


        [HttpPost]
        [AllowAnonymous]
        public ServiceResult<ConstraintViewModel> Create(string name)
        {
            return _constraintCommandService.Create(name);
        }

        [HttpPut]
        [AllowAnonymous]

        public ServiceResult<ConstraintViewModel> Update(int id, UpdateConstraintViewModel model)
        {
            return _constraintCommandService.Update(id, model);
        }


        private readonly IConstraintCommandService _constraintCommandService;
        private readonly IConstraintQueryService _constraintQueryService;
    }
}
