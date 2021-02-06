using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.BindingModels;
using Diba.Core.AppService.Contract.ViewModels;
using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;

namespace Diba.Core.AppService
{
    public class UsersCommandService : IUsersCommandService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersCommandService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            ICustomerRepository customerRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        #region
        public ServiceResult<UserViewModel> Create(CreateUserInputModel request)
        {
            var user = _mapper.Map<User>(request);

            _userRepository.Add(user);

            _unitOfWork.Commit();

            return new ServiceResult<UserViewModel>(_mapper.Map<UserViewModel>(user));
        }

        public ServiceResult<UserViewModel> Delete(DeleteUserInputModel request)
        {
            User user = _userRepository.GetById(request.Id);

            if (user == null)
                return new ServiceResult<UserViewModel>(StatusCode.NotFound);

            _userRepository.Delete(user);
            _unitOfWork.Commit();

            return new ServiceResult<UserViewModel>(_mapper.Map<UserViewModel>(user));
        }

        public ServiceResult<UserViewModel> Update(UpdateUserInputModel request)
        {
            User user = _userRepository.GetById(request.Id);

            if (user == null)
                return new ServiceResult<UserViewModel>(StatusCode.NotFound);

            user.Username = request.Username;

            _unitOfWork.Commit();

            return new ServiceResult<UserViewModel>(_mapper.Map<UserViewModel>(user));
        }

        #endregion

        #region role
        public ServiceResult<CustomerViewModel> CreateCustomer(CreateCustomerInputModel request)
        {
            var customer = _mapper.Map<Customer>(request);
            _customerRepository.Add(customer);
            _unitOfWork.Commit();
            return new ServiceResult<CustomerViewModel>(_mapper.Map<CustomerViewModel>(customer));
        }

        public ServiceResult<CustomerViewModel> UpdateCustomer(UpdateCustomerInputModel request)
        {
            var customer = _customerRepository.GetById(request.Id);

            if (customer == null)
                return new ServiceResult<CustomerViewModel>(StatusCode.NotFound);

            //todo : update customer
            _customerRepository.Update(customer);
            _unitOfWork.Commit();
            return new ServiceResult<CustomerViewModel>(_mapper.Map<CustomerViewModel>(customer));
        }

        public ServiceResult<CustomerViewModel> DeleteCustomer(DeleteCustomerInputModel request)
        {
            var customer = _customerRepository.GetById(request.Id);

            if (customer == null)
                return new ServiceResult<CustomerViewModel>(StatusCode.NotFound);

            _customerRepository.Delete(customer);
            return new ServiceResult<CustomerViewModel>(_mapper.Map<CustomerViewModel>(customer));
        }

        #endregion
    }
}
