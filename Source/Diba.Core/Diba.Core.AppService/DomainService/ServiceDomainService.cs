using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain.DomainService;

namespace Diba.Core.AppService
{
    //Todo: move to domain
    public class ServiceDomainService : IServiceDomainService
    {
        private readonly IBrandRepository _brandRepository;

        public ServiceDomainService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public bool IsBrandExist(long id)
        {
            var brand = _brandRepository.GetById(id);
            return brand != null;
        }
    }
}