using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.ProductConstraint;
using Diba.Core.AppService.Contract.ProductConstraint.Model.ViewModel;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain.Products.ProductConstraints;

namespace Diba.Core.AppService.ProductConstraint
{
    public class ProductStringConstraintsQueryService : IProductStringConstraintsQueryService
    {
        public ProductStringConstraintsQueryService(IProductStringConstraintsRepository productStringConstraintsRepository, IMapper mapper)
        {
            _productStringConstraintsRepository = productStringConstraintsRepository;
            _mapper = mapper;
        }

        public ServiceResult<ProductStringConstraintsViewModel> Get(int id)
        {
            StringConstraint product = _productStringConstraintsRepository.GetById(id);
            return new ServiceResult<ProductStringConstraintsViewModel>(_mapper.Map<ProductStringConstraintsViewModel>(product));
        }

        private readonly IProductStringConstraintsRepository _productStringConstraintsRepository;
        private readonly IMapper _mapper;
    }
}
