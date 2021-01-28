using System;
using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Product;
using Diba.Core.AppService.Contract.Product.Model.InputModels;
using Diba.Core.AppService.Contract.Product.Model.ViewModels;
using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain.Products;

namespace Diba.Core.AppService.Products
{
    public class ProductCommandService : IProductCommandService
    {
        public ProductCommandService(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ServiceResult<ProductViewModel> Create(CreateProductViewModel request)
        {
            var product = _mapper.Map<Product>(request);
            _productRepository.Add(product);
            _unitOfWork.Commit();

            return new ServiceResult<ProductViewModel>(_mapper.Map<ProductViewModel>(product));
        }

        public ServiceResult<ProductViewModel> Update(int id, UpdateProductViewModel request)
        {
            Product product = _productRepository.GetById(id);

            if (product == null)
                return new ServiceResult<ProductViewModel>(StatusCode.NotFound);

            product.Update(name: request.Name);
            //_productRepository.Update(product);
            _unitOfWork.Commit();

            return new ServiceResult<ProductViewModel>(_mapper.Map<ProductViewModel>(product));
        }

        public ServiceResult<ProductViewModel> Delete(int id)
        {
            Product product = _productRepository.GetById(id);

            if (product == null)
                return new ServiceResult<ProductViewModel>(StatusCode.NotFound);

            _productRepository.Delete(product);
            _unitOfWork.Commit();

            return new ServiceResult<ProductViewModel>(_mapper.Map<ProductViewModel>(product));
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
    }
}
