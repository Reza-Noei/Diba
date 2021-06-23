using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Product;
using Diba.Core.AppService.Contract.Product.Model.InputModels;
using Diba.Core.AppService.Contract.Product.Model.ViewModels;
using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain.Products;
using Diba.Core.Domain.Products.ProductConstraints;

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
            ProductClass product = _mapper.Map<ProductClass>(request);
            _productRepository.Add(product);
            _unitOfWork.Commit();

            return new ServiceResult<ProductViewModel>(_mapper.Map<ProductViewModel>(product));
        }

        public ServiceResult<ProductViewModel> Update(int id, UpdateProductViewModel request)
        {
            ProductClass product = _productRepository.GetById(id);

            if (product == null)
                return new ServiceResult<ProductViewModel>(StatusCode.NotFound);

            product.Update(name: request.Name);
            //_productRepository.Update(product);
            _unitOfWork.Commit();

            return new ServiceResult<ProductViewModel>(_mapper.Map<ProductViewModel>(product));
        }

        public ServiceResult<ProductViewModel> UpdateConstraints( UpdateProductConstraintsViewModel request)
        {
            ProductClass product = _productRepository.GetById(request.ProductId);

            if (product == null)
                return new ServiceResult<ProductViewModel>(StatusCode.NotFound);
            var stringConstraints = _mapper.Map<IEnumerable<StringConstraint>>(request.StringConstraints).ToList();
            var selectiveConstraints = _mapper.Map<IEnumerable<SelectiveConstraint>>(request.SelectiveConstraints).ToList();
            var productConstraint = new List<ProductConstraint>();
            productConstraint.AddRange(stringConstraints);
            productConstraint.AddRange(selectiveConstraints);
            product.UpdateConstraints(productConstraint);
            //_productRepository.Update(product);
            _unitOfWork.Commit();

            return new ServiceResult<ProductViewModel>(_mapper.Map<ProductViewModel>(product));
        }

        public ServiceResult<ProductViewModel> Delete(int id)
        {
            ProductClass product = _productRepository.GetById(id);

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
