using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.BindingModels;
using Diba.Core.AppService.Contract.ViewModels;
using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Diba.Core.AppService
{
    public class UsersCommandService : IUsersCommandService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;

        public UsersCommandService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            ICustomerRepository customerRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _customerRepository = customerRepository;
            _roleRepository = roleRepository;
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
        public ServiceResult<CustomerViewModel> GetCustomerByUserId(long userId)
        {
            Customer customer = _roleRepository.GetMany(x => x is Customer && x.UserId == userId).Select(x => x as Customer).FirstOrDefault();
            return new ServiceResult<CustomerViewModel>(_mapper.Map<CustomerViewModel>(customer));
        }

        public ServiceResult<IList<CustomerViewModel>> GetAllCustomers()
        {
            IEnumerable<Customer> roles = _roleRepository.GetMany(x => x is Customer).Select(x => x as Customer);
            return new ServiceResult<IList<CustomerViewModel>>(_mapper.Map<IList<CustomerViewModel>>(roles));
        }

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
        public ServiceResult<AdminViewModel> GetAdminByUserId(long userId)
        {
            Admin admin = _roleRepository.GetMany(x => x is Admin && x.UserId == userId).Select(x => x as Admin).FirstOrDefault();

            if (admin == null)
                return new ServiceResult<AdminViewModel>(StatusCode.NotFound);


            return new ServiceResult<AdminViewModel>(_mapper.Map<AdminViewModel>(admin));
        }

        public ServiceResult<IList<AdminViewModel>> GetAllAdmins()
        {
            IEnumerable<Admin> roles = _roleRepository.GetMany(x=>x is Admin).Select(x => x as Admin);
            return new ServiceResult<IList<AdminViewModel>>(_mapper.Map< IList<AdminViewModel>>(roles));
        }

        public ServiceResult<AdminViewModel> CreateAdmin(long userId)
        {
            var admin = new Admin() { UserId = userId };
            _roleRepository.Add(admin);
            _unitOfWork.Commit();
            return new ServiceResult<AdminViewModel>(_mapper.Map<AdminViewModel>(admin));
        }

        public ServiceResult<AdminViewModel> UpdateAdmin(long userId, UpdateAdminInputModel model)
        {
            Admin admin = _roleRepository.GetMany(x => x is Admin && x.UserId == userId).Select(x => x as Admin).FirstOrDefault();
            if (admin == null)
                return new ServiceResult<AdminViewModel>(StatusCode.NotFound);

            _roleRepository.Update(admin);
            _unitOfWork.Commit();
            return new ServiceResult<AdminViewModel>(_mapper.Map<AdminViewModel>(admin));
        }

        public ServiceResult<AdminViewModel> DeleteAdmin(long userId)
        {
            Admin admin = _roleRepository.GetMany(x => x is Admin && x.UserId == userId).Select(x => x as Admin).FirstOrDefault();
            if (admin == null)
                return new ServiceResult<AdminViewModel>(StatusCode.NotFound);

            _roleRepository.Delete(admin);
            _unitOfWork.Commit();
            return new ServiceResult<AdminViewModel>(_mapper.Map<AdminViewModel>(admin));
        }

        #endregion

        #region Secretary

        public ServiceResult<SecretaryViewModel> GetSecretaryByUserId(long userId)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<IList<SecretaryViewModel>> GetAllSecretarys()
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<SecretaryViewModel> CreateSecretary(int userId, CreateSecretaryInputModel model)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<SecretaryViewModel> UpdateSecretary(long userId, UpdateSecretaryInputModel model)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<SecretaryViewModel> DeleteSecretary(long userId)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}