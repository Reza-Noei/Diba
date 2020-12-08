using Microsoft.AspNetCore.Mvc;

namespace Diba.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationMembershipManagementController : ControllerBase
    {
        public OrganizationMembershipManagementController()
        {

        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
