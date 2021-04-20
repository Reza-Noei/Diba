using System.Collections.Generic;
using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Brands;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;

namespace Diba.Core.AppService.Brands
{
    public class BrandQueryService : IBrandQueryService
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;

        public BrandQueryService(IMapper mapper, IBrandRepository orderRepository)
        {
            _mapper = mapper;
            _brandRepository = orderRepository;
        }

        public ServiceResult<BrandViewModel> Get(long id)
        {
            Brand brand = _brandRepository.GetById(id);

            return new ServiceResult<BrandViewModel>(_mapper.Map<BrandViewModel>(brand));
        }

        public ServiceResult<IEnumerable<BrandViewModel>> GetAll()
        {
            IEnumerable<Brand> brand = _brandRepository.GetAll();

            return new ServiceResult<IEnumerable<BrandViewModel>>(_mapper.Map<IList<BrandViewModel>>(brand));
        }
    }
}
