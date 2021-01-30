using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Dependencies;
using Diba.Core.AppService.Internal;
using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;
using System.Linq;

namespace Diba.Core.AppService
{
    public class CustomerManagementCommand : BaseService, ICustomerManagementCommand
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerManagementCommand(IAuthenticationInformation authenticationInformation,
                                         IOrganizationRepository organizationRepository,
                                         ICustomerRepository customerRepository,
                                         IMapper mapper,
                                         IUnitOfWork unitOfWork):base(authenticationInformation)
        {
            _organizationRepository = organizationRepository;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ServiceResult<CustomerViewModel> Create(CreateCustomerInputModel request)
        {
            var organizationId = base.AuthenticationInformation.OrganizationId;
            var organization = _organizationRepository.GetMany(P => P.Id == organizationId).FirstOrDefault();

            var customerCode = organization.Prefix + "-" + request.Code;

            var customerUser = new User()
            {
                Username = customerCode,
                Password = customerCode
            };

            var role = new BaseRole(RoleEnum.Customer)
            {
                User = customerUser
            };

            var customer = new Customer()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                District = request.District,
                EconomicCode = request.EconomicCode,
                NationalIdentifier = request.NationalIdentifier,
                RegistrationNumber = request.RegistrationNumber,
                PostalCode = request.PostalCode,                
                Referer = organization, 
                Role = role,
                Description = request.Description,
                Code = customerCode,                
            };

            customer.ContactInfos.Add(new ContactInfo()
            {
                Address = request.ContactInfo.Address,
                PhoneNumber = request.ContactInfo.PhoneNumber,
                IsActive = true
            });

            _customerRepository.Add(customer);
            _unitOfWork.Commit();

            return new ServiceResult<CustomerViewModel>(_mapper.Map<CustomerViewModel>(customer));
        }
    }
}
