using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.BindingModels;
using Diba.Core.AppService.Contract.ViewModels;
using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;
using System.Collections.Generic;

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

        #region user
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

        public ServiceResult<UserViewModel> Update(UpdateUserRequest request)
        {
            User user = _userRepository.GetById(request.Id);

            if (user == null)
                return new ServiceResult<UserViewModel>(StatusCode.NotFound);

            user.Username = request.Username;

            _unitOfWork.Commit();

            return new ServiceResult<UserViewModel>(_mapper.Map<UserViewModel>(user));
        }

        #endregion

        #region customer
        public ServiceResult<CustomerViewModel> CreateCustomer(int userId, CreateCustomerInputModel request)
        {
            var customer = _mapper.Map<Customer>(request);
            _customerRepository.Add(customer);
            _unitOfWork.Commit();
            return new ServiceResult<CustomerViewModel>(_mapper.Map<CustomerViewModel>(customer));
        }

        public ServiceResult<CustomerViewModel> UpdateCustomer(long userId, UpdateCustomerInputModel request)
        {
            var customer = _customerRepository.GetById(userId);

            if (customer == null)
                return new ServiceResult<CustomerViewModel>(StatusCode.NotFound);

            //todo : update customer
            _customerRepository.Update(customer);
            _unitOfWork.Commit();
            return new ServiceResult<CustomerViewModel>(_mapper.Map<CustomerViewModel>(customer));
        }

        public ServiceResult<CustomerViewModel> DeleteCustomer(long userId)
        {
            var customer = _customerRepository.GetById(userId);

            if (customer == null)
                return new ServiceResult<CustomerViewModel>(StatusCode.NotFound);

            _customerRepository.Delete(customer);
            return new ServiceResult<CustomerViewModel>(_mapper.Map<CustomerViewModel>(customer));
        }

        #endregion

        #region admin

        public ServiceResult<IList<AdminViewModel>> GetAllAdmins()
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<AdminViewModel> CreateAdmin(long userId, CreateAdminInputModel model)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<AdminViewModel> UpdateAdmin(long userId, UpdateAdminInputModel model)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<AdminViewModel> DeleteAdmin(long userId)
        {
            throw new System.NotImplementedException();
        }


        #endregion
    }
}
