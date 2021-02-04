using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.ViewModels;
using Diba.Core.AppService.Dependencies;
using Diba.Core.AppService.Internal;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Diba.Core.AppService
{
    public class OrganizationMembershipManagementQuery : BaseService, IOrganizationMembershipManagementQuery
    {
        //private readonly ISuperAdminMembershipRepository _superAdminMembershipRepository;
        //private readonly IAdminMembershipRepository _adminMembershipRepository;
        //private readonly ICustomerMembershipRepository _customerMembershipRepository;
        //private readonly ICollectorMembershipRepository _collectorMembershipRepository;
        //private readonly ISecretaryMembershipRepository _secretaryMembershipRepository;
        //private readonly IDeliveryMembershipRepository _deliveryMembershipRepository;

        //private readonly IMapper _mapper;
        //private readonly IUserRepository _userRepository;
        //public OrganizationMembershipManagementQuery(IAuthenticationInformation authenticationInformation,
        //                                             ISuperAdminMembershipRepository superAdminMembershipRepository,
        //                                             IAdminMembershipRepository adminMembershipRepository,
        //                                             ICustomerMembershipRepository customerMembershipRepository,
        //                                             ICollectorMembershipRepository collectorMembershipRepository,
        //                                             ISecretaryMembershipRepository secretaryMembershipRepository,
        //                                             IDeliveryMembershipRepository deliveryMembershipRepository,
        //                                             IUserRepository userRepository,
        //                                             IMapper mapper): base(authenticationInformation)
        //{
        //    _superAdminMembershipRepository = superAdminMembershipRepository;
        //    _adminMembershipRepository = adminMembershipRepository;
        //    _customerMembershipRepository = customerMembershipRepository;
        //    _collectorMembershipRepository = collectorMembershipRepository;
        //    _secretaryMembershipRepository = secretaryMembershipRepository;
        //    _deliveryMembershipRepository = deliveryMembershipRepository;
        //    _userRepository = userRepository;
        //    _mapper = mapper;
        //}

        //public ServiceResult<IEnumerable<OrganizationMembershipViewModel>> GetUserMemberships()
        //{
        //    var userId = base.AuthenticationInformation.UserId;

        //    var user = _userRepository.GetMany(P => P.Id == userId).FirstOrDefault();
        //    if (user == null)
        //        return new ServiceResult<IEnumerable<OrganizationMembershipViewModel>>()
        //        {
        //            Message = new UserNotFoundMessage(),
        //            StatusCode = StatusCode.NotFound
        //        };

        //    List<SuperAdminMembership> superAdminMemberships = _superAdminMembershipRepository.GetMany(P => P.SuperAdmin.Role.UserId == userId).ToList();
        //    List<AdminMembership> adminMemberships = _adminMembershipRepository.GetMany(P => P.Admin.Role.UserId == userId).ToList();
        //    List<SecretaryMembership> secretaryMemberships = _secretaryMembershipRepository.GetMany(P => P.Secretary.Role.UserId == userId).ToList();
        //    List<CustomerMembership> customerMemberships = _customerMembershipRepository.GetMany(P => P.Customer.Role.UserId == userId).ToList();
        //    List<CollectorMembership> collectorMemberships = _collectorMembershipRepository.GetMany(P => P.Collector.Role.UserId == userId).ToList();
        //    List<DeliveryMembership> deliveyMemberships = _deliveryMembershipRepository.GetMany(P => P.Delivery.Role.UserId == userId).ToList();

        //    IEnumerable<OrganizationMembership> memberships = new List<OrganizationMembership>();
        //    memberships = memberships.Union(superAdminMemberships);
        //    memberships = memberships.Union(adminMemberships);
        //    memberships = memberships.Union(collectorMemberships);
        //    memberships = memberships.Union(customerMemberships);
        //    memberships = memberships.Union(deliveyMemberships);
        //    memberships = memberships.Union(secretaryMemberships);

        //    var membershipsViewModel = _mapper.Map<IEnumerable<OrganizationMembershipViewModel>>(memberships);
        //    return new ServiceResult<IEnumerable<OrganizationMembershipViewModel>>(membershipsViewModel);            
        //}
        public OrganizationMembershipManagementQuery(IAuthenticationInformation authenticationInformation) : base(authenticationInformation)
        {
        }

        public ServiceResult<IEnumerable<OrganizationMembershipViewModel>> GetUserMemberships()
        {
            throw new System.NotImplementedException();
        }
    }
}
