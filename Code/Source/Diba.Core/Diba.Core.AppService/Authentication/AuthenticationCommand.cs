using Diba.Core.AppService.Dependencies;
using Diba.Core.AppService.Contract;
using Microsoft.IdentityModel.Tokens;
using Diba.Core.AppService.Contract.BindingModels;
using System.IdentityModel.Tokens.Jwt;
using Diba.Core.Data.Repository.Interfaces;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System;
using Diba.Core.AppService.Internal;
using Diba.Core.Domain;

namespace Diba.Core.AppService
{
    public class AuthenticationCommand : BaseService, IAuthenticationCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly ISuperAdminMembershipRepository _superAdminMembershipRepository;
        private readonly IAdminMembershipRepository _adminMembershipRepository;
        private readonly ICustomerMembershipRepository _customerMembershipRepository;
        private readonly ICollectorMembershipRepository _collectorMembershipRepository;
        private readonly ISecretaryMembershipRepository _secretaryMembershipRepository;
        private readonly IDeliveryMembershipRepository _deliveryMembershipRepository;

        private readonly IJsonWebTokenEngine _jsonWebTokenEngine;
        public AuthenticationCommand(IAuthenticationInformation authenticationInformation,
                                     IJsonWebTokenEngine jsonWebTokenEngine,
                                     ISuperAdminMembershipRepository superAdminMembershipRepository,
                                     IAdminMembershipRepository adminMembershipRepository,
                                     ICustomerMembershipRepository customerMembershipRepository,
                                     ICollectorMembershipRepository collectorMembershipRepository,
                                     ISecretaryMembershipRepository secretaryMembershipRepository,
                                     IDeliveryMembershipRepository deliveryMembershipRepository,
                                     IUserRepository userRepository) : base(authenticationInformation)
        {
            _superAdminMembershipRepository = superAdminMembershipRepository;
            _adminMembershipRepository = adminMembershipRepository;
            _customerMembershipRepository = customerMembershipRepository;
            _collectorMembershipRepository = collectorMembershipRepository;
            _secretaryMembershipRepository = secretaryMembershipRepository;
            _secretaryMembershipRepository = secretaryMembershipRepository;
            _deliveryMembershipRepository = deliveryMembershipRepository;

            _jsonWebTokenEngine = jsonWebTokenEngine;
            _userRepository = userRepository;
        }

        public ServiceResult<string> FirstStepLogin(UserAuthenticationBindingModel model)
        {
            var User = _userRepository.GetMany(P => P.Username == model.Username && P.Password == model.Password).FirstOrDefault();

            if (User == null)
            {
                return new ServiceResult<string>(StatusCode.NotFound, new IncorrectUsernameOrPasswordMessage());
            }

            var token = _jsonWebTokenEngine.GenerateToken(User.Id, User.Username, null, string.Empty, string.Empty);
            return new ServiceResult<string>(token);
        }

        public ServiceResult<string> SecondStepLogin(MembershipAuthenticationBindingModel model)
        {
            var UserId = base.AuthenticationInformation.UserId;
            if (!UserId.HasValue)
                return new ServiceResult<string>()
                {
                    Message = new InvalidTokenMessage(),
                    StatusCode = StatusCode.Forbidden
                };

            var User = _userRepository.GetMany(P => P.Id == UserId).FirstOrDefault();
            if (User == null)
                return new ServiceResult<string>()
                {
                    Message = new InvalidTokenMessage(),
                    StatusCode = StatusCode.NotFound
                };

            RoleEnum Role;
            var RoleConversionResult = Enum.TryParse<RoleEnum>(model.Role, true, out Role);
            if (!RoleConversionResult)
                return new ServiceResult<string>()
                {
                    Message = new InvalidRoleMessage(),
                    StatusCode = StatusCode.BadRequest
                };

            string Token = "";

            switch (Role)
            {
                case RoleEnum.SuperAdmin:
                    SuperAdminMembership SuperAdminMembership = _superAdminMembershipRepository.GetMany(P => P.OrganizationId == model.OrganizationId && P.SuperAdmin.Role.UserId == UserId).FirstOrDefault();
                    if (SuperAdminMembership == null)
                        return new ServiceResult<string>()
                        {
                            Message = new MembershipNotFoundMessage(),
                            StatusCode = StatusCode.NotFound
                        };

                    Token = _jsonWebTokenEngine.GenerateToken(UserId.Value, User.Username, model.OrganizationId, SuperAdminMembership.Organization.Title, Role.ToString("g"));
                    break;
                case RoleEnum.Admin:
                    AdminMembership AdminMembership = _adminMembershipRepository.GetMany(P => P.OrganizationId == model.OrganizationId && P.Admin.Role.UserId == UserId).FirstOrDefault();
                    if (AdminMembership == null)
                        return new ServiceResult<string>()
                        {
                            Message = new MembershipNotFoundMessage(),
                            StatusCode = StatusCode.NotFound
                        };

                    Token = _jsonWebTokenEngine.GenerateToken(UserId.Value, User.Username, model.OrganizationId, AdminMembership.Organization.Title, Role.ToString("g"));
                    break;
                case RoleEnum.Secretary:
                    SecretaryMembership SecretaryMembership = _secretaryMembershipRepository.GetMany(P => P.OrganizationId == model.OrganizationId && P.Secretary.Role.UserId == UserId).FirstOrDefault();
                    if (SecretaryMembership == null)
                        return new ServiceResult<string>()
                        {
                            Message = new MembershipNotFoundMessage(),
                            StatusCode = StatusCode.NotFound
                        };

                    Token = _jsonWebTokenEngine.GenerateToken(UserId.Value, User.Username, model.OrganizationId, SecretaryMembership.Organization.Title, Role.ToString("g"));
                    break;
                case RoleEnum.Collector:
                    CollectorMembership CollectorMembership = _collectorMembershipRepository.GetMany(P => P.OrganizationId == model.OrganizationId && P.Collector.Role.UserId == UserId).FirstOrDefault();
                    if (CollectorMembership == null)
                        return new ServiceResult<string>()
                        {
                            Message = new MembershipNotFoundMessage(),
                            StatusCode = StatusCode.NotFound
                        };

                    Token = _jsonWebTokenEngine.GenerateToken(UserId.Value, User.Username, model.OrganizationId, CollectorMembership.Organization.Title, Role.ToString("g"));
                    break;
                case RoleEnum.Delivery:
                    DeliveryMembership DeliveryMembership = _deliveryMembershipRepository.GetMany(P => P.OrganizationId == model.OrganizationId && P.Delivery.Role.UserId == UserId).FirstOrDefault();
                    if (DeliveryMembership == null)
                        return new ServiceResult<string>()
                        {
                            Message = new MembershipNotFoundMessage(),
                            StatusCode = StatusCode.NotFound
                        };

                    Token = _jsonWebTokenEngine.GenerateToken(UserId.Value, User.Username, model.OrganizationId, DeliveryMembership.Organization.Title, Role.ToString("g"));
                    break;
                case RoleEnum.Customer:
                    CustomerMembership CustomerMembership = _customerMembershipRepository.GetMany(P => P.OrganizationId == model.OrganizationId && P.Customer.Role.UserId == UserId).FirstOrDefault();
                    if (CustomerMembership == null)
                        return new ServiceResult<string>()
                        {
                            Message = new MembershipNotFoundMessage(),
                            StatusCode = StatusCode.NotFound
                        };

                    Token = _jsonWebTokenEngine.GenerateToken(UserId.Value, User.Username, model.OrganizationId, CustomerMembership.Organization.Title, Role.ToString("g"));
                    break;
                default:
                    break;
            }

            return new ServiceResult<string>(Token);
        }
    }
}
