using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Services;
using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;
using Diba.Core.Domain.DomainService;

namespace Diba.Core.AppService.Services
{
    public class ServiceCommandService : IServiceCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;
        private readonly IServiceDomainService _domainService;

        public ServiceCommandService(IUnitOfWork unitOfWork, IMapper mapper, IServiceRepository serviceRepository, IServiceDomainService domainService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _serviceRepository = serviceRepository;
            _domainService = domainService;
        }

        public ServiceResult<ServiceViewModel> Create(CreateServiceInputModel request)
        {
            var service = _mapper.Map<Service>(request);

            service.ModifyFeeByBrands(request.FeeByBrand, _domainService);

            _serviceRepository.Add(service);
            _unitOfWork.Commit();

            return new ServiceResult<ServiceViewModel>(_mapper.Map<ServiceViewModel>(service));
        }

        public ServiceResult<ServiceViewModel> Update(long id, UpdateServiceInputModel request)
        {
            Service service = _serviceRepository.GetById(id);

            if (service == null)
                return new ServiceResult<ServiceViewModel>(StatusCode.NotFound);

            service.ModifyFeeByBrands(request.FeeByBrand, _domainService);

            _serviceRepository.Update(service);
            _unitOfWork.Commit();

            return new ServiceResult<ServiceViewModel>(_mapper.Map<ServiceViewModel>(service));
        }

        public ServiceResult<ServiceViewModel> Delete(long id)
        {
            Service service = _serviceRepository.GetById(id);

            if (service == null)
                return new ServiceResult<ServiceViewModel>(StatusCode.NotFound);

            _serviceRepository.Delete(service);
            _unitOfWork.Commit();

            return new ServiceResult<ServiceViewModel>(_mapper.Map<ServiceViewModel>(service));
        }
    }

}