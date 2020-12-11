using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.ProductConstraint;
using Diba.Core.AppService.Contract.ProductConstraint.Model.ViewModel;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain.Products.ProductConstraints;
using System.Collections.Generic;
using System.Linq;

namespace Diba.Core.AppService.ProductConstraint
{
    public class ProductStringConstraintsQueryService : IProductStringConstraintsQueryService
    {
        public ProductStringConstraintsQueryService(IProductStringConstraintsRepository productStringConstraintsRepository, IMapper mapper, IProductRepository productRepository)
        {
            _productStringConstraintsRepository = productStringConstraintsRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public ServiceResult<ProductStringConstraintsViewModel> Get(int id)
        {
            IEnumerable<StringConstraint> stringConstraint = _productStringConstraintsRepository.GetMany(x => x.ProductId == id);

            var reponse = new ProductStringConstraintsViewModel
            {
                Constraints = _mapper.Map<IList<ProductStringConstraintViewModel>>(stringConstraint)
            };
            return  new ServiceResult<ProductStringConstraintsViewModel>(reponse);
        }

        private readonly IProductStringConstraintsRepository _productStringConstraintsRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
    }
}
