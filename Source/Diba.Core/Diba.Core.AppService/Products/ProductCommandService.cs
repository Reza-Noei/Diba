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

        public ServiceResult<ProductViewModel> CreateFinalProduct(CreateFinalProductViewModel command)
        {
            GenericProduct parent = null;
            if (command.ParentId != null) parent = (GenericProduct)_productRepository.GetById((int)command.ParentId);

            Product finalProduct = new FinalProduct(command.Name, parent);

            _productRepository.Add(finalProduct);
            _unitOfWork.Commit();

            return new ServiceResult<ProductViewModel>(_mapper.Map<ProductViewModel>(finalProduct));
        }

        public ServiceResult<ProductViewModel> CreateGenericProduct(CreateGenericProductViewModel command)
        {
            GenericProduct parent = null;
            if (command.ParentId != null) parent = (GenericProduct)_productRepository.GetById((int)command.ParentId);

            var genericProduct = new GenericProduct(command.Name, parent);

            var productConstraint = ConvertProductConstraints(command.StringConstraints, command.SelectiveConstraints);
            genericProduct.UpdateConstraints(productConstraint);

            _productRepository.Add(genericProduct);
            _unitOfWork.Commit();

            return new ServiceResult<ProductViewModel>(_mapper.Map<ProductViewModel>(genericProduct));
        }

        public ServiceResult<ProductViewModel> UpdateFinalProduct(UpdateFinalProductViewModel model)
        {
            Product product = _productRepository.GetById(model.ProductId);

            if (product == null)
                return new ServiceResult<ProductViewModel>(StatusCode.NotFound);

            product.Update(name: model.Name);
            _unitOfWork.Commit();

            return new ServiceResult<ProductViewModel>(_mapper.Map<ProductViewModel>(product));
        }

        public ServiceResult<ProductViewModel> UpdateGenericProduct(UpdateGenericProductViewModel command)
        {
            GenericProduct parent = null;
            if (command.ParentId != null) parent = (GenericProduct)_productRepository.GetById((int)command.ParentId);

            var genericProduct = new GenericProduct(command.Name, parent);

            genericProduct.Update(name: command.Name);

            var productConstraint = ConvertProductConstraints(command.StringConstraints, command.SelectiveConstraints);
            genericProduct.UpdateConstraints(productConstraint);

            _productRepository.Add(genericProduct);
            _unitOfWork.Commit();

            return new ServiceResult<ProductViewModel>(_mapper.Map<ProductViewModel>(genericProduct));
        }

        private List<ProductConstraint> ConvertProductConstraints(IList<ProductStringConstraintsViewModel> stringConstraints, IList<ProductSelectiveConstraintsViewModel>  selectiveConstraints)
        {
            var _stringConstraints = _mapper.Map<IEnumerable<StringConstraint>>(stringConstraints).ToList();
            var _selectiveConstraints = SelectiveConstraintMappers.Map(selectiveConstraints);
            var productConstraint = new List<ProductConstraint>();
            productConstraint.AddRange(_stringConstraints);
            productConstraint.AddRange(_selectiveConstraints);
            return productConstraint;
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
