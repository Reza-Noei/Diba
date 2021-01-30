using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Product;
using Diba.Core.AppService.Contract.Product.Model.ViewModels;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain.Products;
using System.Collections.Generic;

namespace Diba.Core.AppService.Products
{
    public class ProductQueryService : IProductQueryService
    {
        public ProductQueryService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public ServiceResult<ProductViewModel> Get(int id)
        {
            Product product = _productRepository.GetById(id);
            return new ServiceResult<ProductViewModel>(_mapper.Map<ProductViewModel>(product));
        }

        public ServiceResult<IEnumerable<ProductViewModel>> GetList()
        {
            IEnumerable<Product> products = _productRepository.GetAll();
            return new ServiceResult<IEnumerable<ProductViewModel>>(_mapper.Map<IEnumerable<ProductViewModel>>(products));
        }

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
    }
}