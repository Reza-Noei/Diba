using Diba.Core.AppService.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Diba.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationManagementController : Controller
    {
        private readonly IOrganizationManagementQuery _organizationManagementQuery;

        /// <summary>
        /// کوئری برروی مدیریت سازمانها
        /// </summary>
        /// <param name="organizationManagementQuery"></param>
        public OrganizationManagementController(IOrganizationManagementQuery organizationManagementQuery)
        {
            _organizationManagementQuery = organizationManagementQuery;
        }

        /// <summary>
        /// اطلاعات سازمان من
        /// </summary>
        /// <returns>اطلاعات سازمان</returns>
        [HttpGet]
        [Route("/Me")]
        public ServiceResult<OrganizationViewModel> Get()
        {
            return _organizationManagementQuery.MyOrganization();
        }
    }
}