using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.BindingModels;
using Diba.Core.AppService.Contract.ViewModels;
using AutoMapper;
using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;
using System.Collections.Generic;

namespace Diba.Core.AppService
{
    public class UserManagementQuery : IUserManagementQuery
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserManagementQuery(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ServiceResult<UserViewModel> Get(GetUserBindingModel request)
        {
            User user = _userRepository.GetById(request.Id);
            return new ServiceResult<UserViewModel>(_mapper.Map<UserViewModel>(user));
        }

        public ServiceResult<IList<UserViewModel>> GetAll(GetAllUserBindingModel getAllUserBindingModel)
        {
            IEnumerable<User> user = _userRepository.GetAll();
            return new ServiceResult<IList<UserViewModel>>(_mapper.Map<IList<UserViewModel>>(user));
        }
    }
}
