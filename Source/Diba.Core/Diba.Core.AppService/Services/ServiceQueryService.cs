using System.Collections.Generic;
using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Services;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;

namespace Diba.Core.AppService.Services
{
    public class ServiceQueryService : IServiceQueryService
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;

        public ServiceQueryService(IMapper mapper, IServiceRepository orderRepository)
        {
            _mapper = mapper;
            _serviceRepository = orderRepository;
        }

        public ServiceResult<ServiceViewModel> Get(long id)
        {
            Service service = _serviceRepository.GetById(id);

            return new ServiceResult<ServiceViewModel>(_mapper.Map<ServiceViewModel>(service));
        }

        public ServiceResult<IEnumerable<ServiceViewModel>> GetAll()
        {
            IEnumerable<Service> service = _serviceRepository.GetAll();

            return new ServiceResult<IEnumerable<ServiceViewModel>>(_mapper.Map<IList<ServiceViewModel>>(service));
        }
    }
}