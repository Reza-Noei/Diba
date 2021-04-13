using Diba.Core.AppService.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Diba.Core.AppService.Contract.Companies;

namespace Diba.Core.WebApi.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        public CompanyController(ICompanyQueryService companyQueryService, ICompanyCommandService companyCommandService)
        {
            _companyQueryService = companyQueryService;
            _companyCommandService = companyCommandService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        public ServiceResult<CompanyViewModel> Get(int id)
        {
            ServiceResult<CompanyViewModel> company = _companyQueryService.Get(id);
            return company;
        }

        [HttpGet]
        [AllowAnonymous]
        public ServiceResult<IEnumerable<CompanyViewModel>> GetList()
        {
            ServiceResult<IEnumerable<CompanyViewModel>> companies = _companyQueryService.GetAll();
            return companies;
        }

        [HttpPost]
        [AllowAnonymous]
        public ServiceResult<CompanyViewModel> Create(CreateCompanyInputModel model)
        {
            return _companyCommandService.Create(model);
        }

        [HttpPatch]
        [AllowAnonymous]
        [Route("{id}")]
        public ServiceResult<CompanyViewModel> Update(long id, UpdateCompanyInputModel model)
        {
            return _companyCommandService.Update(id, model);
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("{id}")]
        public ServiceResult<CompanyViewModel> Delete(long id)
        {
            return _companyCommandService.Delete(id);
        }

        private readonly ICompanyCommandService _companyCommandService;
        private readonly ICompanyQueryService _companyQueryService;
    }
}