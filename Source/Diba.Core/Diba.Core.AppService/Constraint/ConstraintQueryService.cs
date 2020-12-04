using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Constraint;
using Diba.Core.AppService.Contract.Constraint.Model.ViewModels;
using Diba.Core.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Constraint
{
    public class ConstraintQueryService : IConstraintQueryService
    {
        public ConstraintQueryService(IConstraintRepository constraintRepository, IMapper mapper)
        {
            _constraintRepository = constraintRepository;
            _mapper = mapper;
        }
        public ServiceResult<ConstraintViewModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<IEnumerable<ConstraintViewModel>> GetList()
        {
            throw new NotImplementedException();
        }

        private readonly IMapper _mapper;
        private readonly IConstraintRepository _constraintRepository;
    }
}
