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
    public class ProductSelectiveConstraintsQueryService : IProductSelectiveConstraintsQueryService
    {
        public ProductSelectiveConstraintsQueryService(IProductSelectiveConstraintsRepository productSelectiveConstraintsRepository, IMapper mapper)
        {
            _productSelectiveConstraintsRepository = productSelectiveConstraintsRepository;
            _mapper = mapper;
        }

        public ServiceResult<ProductSelectiveConstraintsViewModel> Get(int id)
        {
            IEnumerable<SelectiveConstraint> selectiveConstraint = _productSelectiveConstraintsRepository.GetMany(x => x.ProductId == id);
            var a = selectiveConstraint.ToList();

            var reponse = new ProductSelectiveConstraintsViewModel
            {
                Constraints = _mapper.Map<IList<ProductSelectiveConstraintViewModel>>(selectiveConstraint)
            };
            return new ServiceResult<ProductSelectiveConstraintsViewModel>(reponse);
        }

        private readonly IProductSelectiveConstraintsRepository _productSelectiveConstraintsRepository;
        private readonly IMapper _mapper;
    }
}
