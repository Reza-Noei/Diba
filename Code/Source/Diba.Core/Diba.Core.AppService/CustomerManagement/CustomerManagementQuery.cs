using AutoMapper;
using Diba.Core.AppService.Contract;
using System.Collections.Generic;
using Diba.Core.Data.Repository.Interfaces;

namespace Diba.Core.AppService
{
    public class CustomerManagementQuery : ICustomerManagementQuery
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerManagementQuery(ICustomerRepository customerRepository, 
                                       IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
            
        public ServiceResult<IEnumerable<CustomerViewModel>> Search(CustomerSearchInputModel request)
        {
            return new ServiceResult<IEnumerable<CustomerViewModel>>(_mapper.Map<IEnumerable<CustomerViewModel>>(_customerRepository.GetAll()));
        }
    }
}
