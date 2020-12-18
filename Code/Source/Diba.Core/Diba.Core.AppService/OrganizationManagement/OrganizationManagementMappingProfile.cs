using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService
{
    public class OrganizationManagementMappingProfile : Profile
    {
        public OrganizationManagementMappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Organization, OrganizationViewModel>().ConvertUsing(src => new OrganizationViewModel()
            {
                Id = src.Id,
                Title = src.Title,
                Prefix = src.Prefix
            });
        }
    }
}
