using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.ViewModels;
using AutoMapper;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;
using System.Collections.Generic;

namespace Diba.Core.AppService
{
    public class UsersQueryService : IUsersQueryService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UsersQueryService(IUserRepository userRepository, IMapper mapper, ICustomerRepository customerRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        #region User
        public ServiceResult<UserViewModel> Get(GetUserInputModel request)
        {
            User user = _userRepository.GetById(request.Id);
            return new ServiceResult<UserViewModel>(_mapper.Map<UserViewModel>(user));
        }

        public ServiceResult<IList<UserViewModel>> GetAll(GetAllUserInputModel request)
        {
            IEnumerable<User> user = _userRepository.GetAll();
            return new ServiceResult<IList<UserViewModel>>(_mapper.Map<IList<UserViewModel>>(user));
        }

        #endregion

        #region customer
        public ServiceResult<CustomerViewModel> GetCustomer(GetCustomerInputModel request)
        {
            Customer customer = _customerRepository.GetById(request.Id);
            return new ServiceResult<CustomerViewModel>(_mapper.Map<CustomerViewModel>(customer));
        }

        public ServiceResult<IList<CustomerViewModel>> GetAllCustomer(GetAllCustomersInputModel request)
        {
            IEnumerable<Customer> customers = _customerRepository.GetAll();
            return new ServiceResult<IList<CustomerViewModel>>(_mapper.Map<IList<CustomerViewModel>>(customers));
        }

        #endregion
    }
}