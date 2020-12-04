using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Constraint;
using Diba.Core.AppService.Contract.Constraint.Model.InputModels;
using Diba.Core.AppService.Contract.Constraint.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


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

        [HttpPost]
        [AllowAnonymous]
        public ServiceResult<ConstraintViewModel> Create(string name)
        {
            return _constraintCommandService.Create(name);
        }


        private readonly IConstraintCommandService _constraintCommandService;
        private readonly IConstraintQueryService _constraintQueryService;
    }
}
