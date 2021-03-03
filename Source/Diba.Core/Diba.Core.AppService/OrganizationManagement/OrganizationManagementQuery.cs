using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Dependencies;
using Diba.Core.AppService.Internal;
using Diba.Core.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diba.Core.AppService
{
    public class OrganizationManagementQuery : BaseService, IOrganizationManagementQuery
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;

        public OrganizationManagementQuery(IAuthenticationInformation authenticationInformation,
                                           IOrganizationRepository organizationRepository,
                                           IMapper mapper): base(authenticationInformation)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public ServiceResult<OrganizationViewModel> MyOrganization()
        {
            throw new NotImplementedException();
        }
    }
}
