using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Companies;
using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;

namespace Diba.Core.AppService.Companies
{

    public class CompanyCommandService : ICompanyCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public CompanyCommandService(IUnitOfWork unitOfWork, IMapper mapper, ICompanyRepository companyRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public ServiceResult<CompanyViewModel> Create(CreateCompanyInputModel request)
        {
            var company = _mapper.Map<Company>(request);
            _companyRepository.Add(company);
            _unitOfWork.Commit();

            return new ServiceResult<CompanyViewModel>(_mapper.Map<CompanyViewModel>(company));
        }

        public ServiceResult<CompanyViewModel> Update(long id, UpdateCompanyInputModel request)
        {
            Company company = _companyRepository.GetById(id);

            if (company == null)
                return new ServiceResult<CompanyViewModel>(StatusCode.NotFound);

            _companyRepository.Update(company);
            _unitOfWork.Commit();

            return new ServiceResult<CompanyViewModel>(_mapper.Map<CompanyViewModel>(company));
        }

        public ServiceResult<CompanyViewModel> Delete(long id)
        {
            Company company = _companyRepository.GetById(id);

            if (company == null)
                return new ServiceResult<CompanyViewModel>(StatusCode.NotFound);

            _companyRepository.Delete(company);
            _unitOfWork.Commit();

            return new ServiceResult<CompanyViewModel>(_mapper.Map<CompanyViewModel>(company));
        }
    }
}