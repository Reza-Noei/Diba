using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.ProductConstraint;
using Diba.Core.AppService.Contract.ProductConstraint.Model.ViewModel;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain.Products.ProductConstraints;

namespace Diba.Core.AppService.ProductConstraint
{
    public class ProductSelectiveConstraintsQueryService : IProductSelectiveConstraintsQueryService
    {
        public ProductSelectiveConstraintsQueryService(IProductStringConstraintsRepository productStringConstraintsRepository, IMapper mapper)
        {
            _productStringConstraintsRepository = productStringConstraintsRepository;
            _mapper = mapper;
        }

        public ServiceResult<ProductSelectiveConstraintsViewModel> Get(int id)
        {
            StringConstraint product = _productStringConstraintsRepository.GetById(id);
            return new ServiceResult<ProductSelectiveConstraintsViewModel>(_mapper.Map<ProductSelectiveConstraintsViewModel>(product));
        }

        private readonly IProductStringConstraintsRepository _productStringConstraintsRepository;
        private readonly IMapper _mapper;
    }
}
