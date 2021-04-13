using System.Collections.Generic;
using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Companies;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;

namespace Diba.Core.AppService.Companies
{
    public class CompanyQueryService : ICompanyQueryService
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public CompanyQueryService(IMapper mapper, ICompanyRepository orderRepository)
        {
            _mapper = mapper;
            _companyRepository = orderRepository;
        }

        public ServiceResult<CompanyViewModel> Get(long id)
        {
            Company company = _companyRepository.GetById(id);

            return new ServiceResult<CompanyViewModel>(_mapper.Map<CompanyViewModel>(company));
        }

        public ServiceResult<IEnumerable<CompanyViewModel>> GetAll()
        {
            IEnumerable<Company> company = _companyRepository.GetAll();

            return new ServiceResult<IEnumerable<CompanyViewModel>>(_mapper.Map<IList<CompanyViewModel>>(company));
        }
    }
}
