using AutoMapper;
using Diba.Core.AppService.Contract;
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
            try
            {
                var user = _mapper.Map<User>(request);
                _userRepository.Add(user);
                _unitOfWork.Commit();
                return new ServiceResult<UserViewModel>(_mapper.Map<UserViewModel>(user));
            }
            catch (System.Exception)
            {
                return new ServiceResult<UserViewModel>(StatusCode.InternalServerError);
            }
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
            try
            {
                var customer = _mapper.Map<Customer>(request);
                _customerRepository.Add(customer);
                _unitOfWork.Commit();
                return new ServiceResult<CustomerViewModel>(_mapper.Map<CustomerViewModel>(customer));
            }
            catch (System.Exception)
            {
                return new ServiceResult<CustomerViewModel>(StatusCode.InternalServerError);
            }
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
            Customer customer = _customerRepository.GetById(userId);

            if (customer == null)
                return new ServiceResult<CustomerViewModel>(StatusCode.NotFound);

            _customerRepository.Delete(customer);
            return new ServiceResult<CustomerViewModel>(_mapper.Map<CustomerViewModel>(customer));
        }

        #endregion

        #region admin
        public ServiceResult<AdminViewModel> GetAdminByUserId(long userId)
        {
            Admin admin = _roleRepository.Get(x => x is Admin && x.UserId == userId) as Admin;

            if (admin == null)
                return new ServiceResult<AdminViewModel>(StatusCode.NotFound);

            return new ServiceResult<AdminViewModel>(_mapper.Map<AdminViewModel>(admin));
        }

        public ServiceResult<IList<AdminViewModel>> GetAllAdmins()
        {
            IEnumerable<Admin> admins = _roleRepository.GetMany(x => x is Admin).Select(x => x as Admin);
            return new ServiceResult<IList<AdminViewModel>>(_mapper.Map<IList<AdminViewModel>>(admins));
        }

        public ServiceResult<AdminViewModel> CreateAdmin(long userId)
        {
            try
            {
                var admin = new Admin() { UserId = userId };
                _roleRepository.Add(admin);
                _unitOfWork.Commit();
                return new ServiceResult<AdminViewModel>(_mapper.Map<AdminViewModel>(admin));
            }
            catch (System.Exception)
            {
                return new ServiceResult<AdminViewModel>(StatusCode.InternalServerError);
            }
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
            Secretary admin = _roleRepository.Get(x => x is Secretary && x.UserId == userId) as Secretary;

            if (admin == null)
                return new ServiceResult<SecretaryViewModel>(StatusCode.NotFound);

            return new ServiceResult<SecretaryViewModel>(_mapper.Map<SecretaryViewModel>(admin));
        }

        public ServiceResult<IList<SecretaryViewModel>> GetAllSecretarys()
        {
            IEnumerable<Secretary> secretaries = _roleRepository.GetMany(x => x is Secretary).Select(x => x as Secretary);
            return new ServiceResult<IList<SecretaryViewModel>>(_mapper.Map<IList<SecretaryViewModel>>(secretaries));
        }

        public ServiceResult<SecretaryViewModel> CreateSecretary(int userId, CreateSecretaryInputModel model)
        {
            try
            {
                var secretary = new Secretary() { UserId = userId };
                _roleRepository.Add(secretary);
                _unitOfWork.Commit();
                return new ServiceResult<SecretaryViewModel>(_mapper.Map<SecretaryViewModel>(secretary));
            }
            catch (System.Exception)
            {
                return new ServiceResult<SecretaryViewModel>(StatusCode.InternalServerError);
            }
        }

        public ServiceResult<SecretaryViewModel> UpdateSecretary(long userId, UpdateSecretaryInputModel model)
        {
            Secretary admin = _roleRepository.Get(x => x is Secretary && x.UserId == userId) as Secretary;
            if (admin == null)
                return new ServiceResult<SecretaryViewModel>(StatusCode.NotFound);

            _roleRepository.Update(admin);
            _unitOfWork.Commit();
            return new ServiceResult<SecretaryViewModel>(_mapper.Map<SecretaryViewModel>(admin));
        }

        public ServiceResult<SecretaryViewModel> DeleteSecretary(long userId)
        {
            Secretary secretary = _roleRepository.Get(x => x is Secretary && x.UserId == userId) as Secretary;

            if (secretary == null)
                return new ServiceResult<SecretaryViewModel>(StatusCode.NotFound);

            _roleRepository.Delete(secretary);
            return new ServiceResult<SecretaryViewModel>(_mapper.Map<SecretaryViewModel>(secretary));
        }
        #endregion

        #region Delivery

        public ServiceResult<DeliveryViewModel> GetDeliveryByUserId(long userId)
        {
            Delivery delivery = _roleRepository.Get(x => x is Delivery && x.UserId == userId) as Delivery;

            if (delivery == null)
                return new ServiceResult<DeliveryViewModel>(StatusCode.NotFound);

            return new ServiceResult<DeliveryViewModel>(_mapper.Map<DeliveryViewModel>(delivery));
        }

        public ServiceResult<IList<DeliveryViewModel>> GetAllDeliverys()
        {
            IEnumerable<Delivery> deliveries = _roleRepository.GetMany(x => x is Delivery).Select(x => x as Delivery);
            return new ServiceResult<IList<DeliveryViewModel>>(_mapper.Map<IList<DeliveryViewModel>>(deliveries));
        }

        public ServiceResult<DeliveryViewModel> CreateDelivery(int userId, CreateDeliveryInputModel model)
        {
            try
            {
                var delivery = new Delivery() { UserId = userId };
                _roleRepository.Add(delivery);
                _unitOfWork.Commit();
                return new ServiceResult<DeliveryViewModel>(_mapper.Map<DeliveryViewModel>(delivery));
            }
            catch (System.Exception)
            {
                return new ServiceResult<DeliveryViewModel>(StatusCode.NotFound);
            }
        }

        public ServiceResult<DeliveryViewModel> UpdateDelivery(long userId, UpdateDeliveryInputModel model)
        {
            Delivery delivery = _roleRepository.Get(x => x is Delivery && x.UserId == userId) as Delivery;

            if (delivery == null)
                return new ServiceResult<DeliveryViewModel>(StatusCode.NotFound);

            _roleRepository.Update(delivery);
            _unitOfWork.Commit();
            return new ServiceResult<DeliveryViewModel>(_mapper.Map<DeliveryViewModel>(delivery));
        }

        public ServiceResult<DeliveryViewModel> DeleteDelivery(long userId)
        {
            Delivery delivery = _roleRepository.Get(x => x is Delivery && x.UserId == userId) as Delivery;

            if (delivery == null)
                return new ServiceResult<DeliveryViewModel>(StatusCode.NotFound);
            
            _roleRepository.Delete(delivery);
            return new ServiceResult<DeliveryViewModel>(_mapper.Map<DeliveryViewModel>(delivery));
        }
        #endregion

        #region Collector

        public ServiceResult<CollectorViewModel> GetCollectorByUserId(long userId)
        {
            Collector collector = _roleRepository.Get(x => x is Collector && x.UserId == userId) as Collector;

            if (collector == null)
                return new ServiceResult<CollectorViewModel>(StatusCode.NotFound);

            return new ServiceResult<CollectorViewModel>(_mapper.Map<CollectorViewModel>(collector));
        }

        public ServiceResult<IList<CollectorViewModel>> GetAllCollectors()
        {
            IEnumerable<Collector> collectors = _roleRepository.GetMany(x => x is Collector).Select(x => x as Collector);
            return new ServiceResult<IList<CollectorViewModel>>(_mapper.Map<IList<CollectorViewModel>>(collectors));
        }

        public ServiceResult<CollectorViewModel> CreateCollector(int userId, CreateCollectorInputModel model)
        {
            try
            {
                var collector = new Collector() { UserId = userId };
                _roleRepository.Add(collector);
                _unitOfWork.Commit();
                return new ServiceResult<CollectorViewModel>(_mapper.Map<CollectorViewModel>(collector));
            }
            catch (System.Exception)
            {
                return new ServiceResult<CollectorViewModel>(StatusCode.InternalServerError);
            }
        }

        public ServiceResult<CollectorViewModel> UpdateCollector(long userId, UpdateCollectorInputModel model)
        {
            Collector collector = _roleRepository.Get(x => x is Collector && x.UserId == userId) as Collector;

            if (collector == null)
                return new ServiceResult<CollectorViewModel>(StatusCode.NotFound);

            _roleRepository.Update(collector);
            _unitOfWork.Commit();
            return new ServiceResult<CollectorViewModel>(_mapper.Map<CollectorViewModel>(collector));
        }

        public ServiceResult<CollectorViewModel> DeleteCollector(long userId)
        {
            Collector collector = _roleRepository.Get(x => x is Collector && x.UserId == userId) as Collector;

            if (collector == null)
                return new ServiceResult<CollectorViewModel>(StatusCode.NotFound);

            _roleRepository.Delete(collector);
            return new ServiceResult<CollectorViewModel>(_mapper.Map<CollectorViewModel>(collector));
        }
        #endregion

        #region SuperAdmin

        public ServiceResult<SuperAdminViewModel> GetSuperAdminByUserId(long userId)
        {
            Role superAdmin = _roleRepository.Get(x => x is SuperAdmin && x.UserId == userId) as SuperAdmin;

            if (superAdmin == null)
                return new ServiceResult<SuperAdminViewModel>(StatusCode.NotFound);

            return new ServiceResult<SuperAdminViewModel>(_mapper.Map<SuperAdminViewModel>(superAdmin));
        }

        public ServiceResult<IList<SuperAdminViewModel>> GetAllSuperAdmins()
        {
            IEnumerable<SuperAdmin> superAdmins = _roleRepository.GetMany(x => x is SuperAdmin).Select(x => x as SuperAdmin);
            return new ServiceResult<IList<SuperAdminViewModel>>(_mapper.Map<IList<SuperAdminViewModel>>(superAdmins));
        }

        public ServiceResult<SuperAdminViewModel> CreateSuperAdmin(int userId, CreateSuperAdminInputModel model)
        {
            try
            {
                SuperAdmin superAdmin = new SuperAdmin() { UserId = userId };
                _roleRepository.Add(superAdmin);
                _unitOfWork.Commit();
                return new ServiceResult<SuperAdminViewModel>(_mapper.Map<SuperAdminViewModel>(superAdmin));
            }
            catch (System.Exception)
            {
                return new ServiceResult<SuperAdminViewModel>(StatusCode.InternalServerError);
            }
        }

        public ServiceResult<SuperAdminViewModel> UpdateSuperAdmin(long userId, UpdateSuperAdminInputModel model)
        {
            Role superAdmin = _roleRepository.Get(x => x is SuperAdmin && x.UserId == userId) as SuperAdmin;
            if (superAdmin == null)
                return new ServiceResult<SuperAdminViewModel>(StatusCode.NotFound);

            _roleRepository.Update(superAdmin);
            _unitOfWork.Commit();
            return new ServiceResult<SuperAdminViewModel>(_mapper.Map<SuperAdminViewModel>(superAdmin));
        }

        public ServiceResult<SuperAdminViewModel> DeleteSuperAdmin(long userId)
        {
            SuperAdmin superAdmin = _roleRepository.Get(x => x is SuperAdmin && x.UserId == userId) as SuperAdmin;

            if (superAdmin == null)
                return new ServiceResult<SuperAdminViewModel>(StatusCode.NotFound);

            _roleRepository.Delete(superAdmin);
            return new ServiceResult<SuperAdminViewModel>(_mapper.Map<SuperAdminViewModel>(superAdmin));
        }

        #endregion
    }
}