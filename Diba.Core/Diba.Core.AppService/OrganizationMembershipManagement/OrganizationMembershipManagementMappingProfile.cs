using AutoMapper;
using Diba.Core.AppService.Contract.BindingModels;
using Diba.Core.AppService.Contract.ViewModels;
using Diba.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService
{
    public class OrganizationMembershipManagementMappingProfile : Profile
    {
        public OrganizationMembershipManagementMappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<SecretaryMembership, OrganizationMembershipViewModel>().ConvertUsing(src => new OrganizationMembershipViewModel()
            {
                OrganizationId = src.OrganizationId,
                OrganizationTitle = src.Organization.Title,
                RoleTitle = src.Secretary.Role.Title,
                UserDisplayName = src.Secretary.Role.User.Username,
                UserId = src.Secretary.Role.UserId
            });

            CreateMap<CustomerMembership, OrganizationMembershipViewModel>().ConvertUsing(src => new OrganizationMembershipViewModel()
            {
                OrganizationId = src.OrganizationId,
                OrganizationTitle = src.Organization.Title,
                RoleTitle = src.Customer.Role.Title,
                UserDisplayName = src.Customer.Role.User.Username,
                UserId = src.Customer.Role.UserId
            });

            CreateMap<SuperAdminMembership, OrganizationMembershipViewModel>().ConvertUsing(src => new OrganizationMembershipViewModel()
            {
                OrganizationId = src.OrganizationId,
                OrganizationTitle = src.Organization.Title,
                RoleTitle = src.SuperAdmin.Role.Title,
                UserDisplayName = src.SuperAdmin.Role.User.Username,
                UserId = src.SuperAdmin.Role.UserId
            });


            CreateMap<AdminMembership, OrganizationMembershipViewModel>().ConvertUsing(src => new OrganizationMembershipViewModel()
            {
                OrganizationId = src.OrganizationId,
                OrganizationTitle = src.Organization.Title,
                RoleTitle = src.Admin.Role.Title,
                UserDisplayName = src.Admin.Role.User.Username,
                UserId = src.Admin.Role.UserId
            });

            CreateMap<DeliveryMembership, OrganizationMembershipViewModel>().ConvertUsing(src => new OrganizationMembershipViewModel()
            {
                OrganizationId = src.OrganizationId,
                OrganizationTitle = src.Organization.Title,
                RoleTitle = src.Delivery.Role.Title,
                UserDisplayName = src.Delivery.Role.User.Username,
                UserId = src.Delivery.Role.UserId
            });

            CreateMap<CollectorMembership, OrganizationMembershipViewModel>().ConvertUsing(src => new OrganizationMembershipViewModel()
            {
                OrganizationId = src.OrganizationId,
                OrganizationTitle = src.Organization.Title,
                RoleTitle = src.Collector.Role.Title,
                UserDisplayName = src.Collector.Role.User.Username,
                UserId = src.Collector.Role.UserId
            });

            CreateMap<CreateUserBindingModel, User>();
        }
    }
}
