using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.BindingModels;
using Diba.Core.AppService.Contract.ViewModels;
using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;

namespace Diba.Core.AppService
{
    public class UserManagementCommand : IUserManagementCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserManagementCommand(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ServiceResult<UserViewModel> Create(CreateUserBindingModel request)
        {
            var User = _mapper.Map<Domain.User>(request);

            _userRepository.Add(User);

            _unitOfWork.Commit();

            return new ServiceResult<UserViewModel>(_mapper.Map<UserViewModel>(User));
        }
    }
}
