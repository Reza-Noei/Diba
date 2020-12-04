using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Constraint;
using Diba.Core.AppService.Contract.Constraint.Model.ViewModels;
using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;

namespace Diba.Core.AppService
{
    public class ConstraintCommandService : IConstraintCommandService
    {
        public ConstraintCommandService(IConstraintRepository constraintRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _constraintRepository = constraintRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ServiceResult<ConstraintViewModel> Create(string title)
        {
            var constraint = new Domain.Constraints.Constraint(title);
            _constraintRepository.Add(constraint);
            _unitOfWork.Commit();

            return new ServiceResult<ConstraintViewModel>(_mapper.Map<ConstraintViewModel>(constraint));
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConstraintRepository _constraintRepository;
    }
}
