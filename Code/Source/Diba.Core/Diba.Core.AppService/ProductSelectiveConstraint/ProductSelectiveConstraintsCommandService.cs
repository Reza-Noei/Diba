using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.ProductConstraint;
using Diba.Core.AppService.Contract.ProductConstraint.Model.ViewModel;
using Diba.Core.AppService.Contract.ProductStringConstraint.Model.InputModel;
using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain.Products.ProductConstraints;
using System.Collections.Generic;

namespace Diba.Core.AppService.Products
{
    public class ProductSelectiveConstraintsCommandService : IProductSelectiveConstraintsCommandService
    {
        public ProductSelectiveConstraintsCommandService(IMapper mapper, IUnitOfWork unitOfWork, IProductSelectiveConstraintsRepository productSelectiveConstraintsRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productSelectiveConstraintsRepository = productSelectiveConstraintsRepository;
        }

        public ServiceResult<ProductSelectiveConstraintViewModel> Create(int productId, CreateProductSelectiveConstraintsViewModel request)
        {

            var selectiveConstraint = new SelectiveConstraint()
            {
                ProductId = productId,
                Title = request.Title,
                Options = _mapper.Map<ICollection<Option>>(request.Options) 
            };
            _productSelectiveConstraintsRepository.Add(selectiveConstraint);
            _unitOfWork.Commit();

            return new ServiceResult<ProductSelectiveConstraintViewModel>(_mapper.Map<ProductSelectiveConstraintViewModel>(selectiveConstraint));

        }

        public ServiceResult<ProductSelectiveConstraintViewModel> Update(int productId, int constraintId, UpdateProductSelectiveConstraintsViewModel request)
        {
            SelectiveConstraint seletiveConstraint = _productSelectiveConstraintsRepository.GetById(constraintId);

            if (seletiveConstraint == null)
                return new ServiceResult<ProductSelectiveConstraintViewModel>(StatusCode.NotFound);

            seletiveConstraint.Update(title: request.Title);
            _unitOfWork.Commit();

            return new ServiceResult<ProductSelectiveConstraintViewModel>(_mapper.Map<ProductSelectiveConstraintViewModel>(seletiveConstraint));
        }

        public ServiceResult<ProductSelectiveConstraintViewModel> Delete(int id)
        {
            SelectiveConstraint stringConstraint = _productSelectiveConstraintsRepository.GetById(id);

            if (stringConstraint == null)
                return new ServiceResult<ProductSelectiveConstraintViewModel>(StatusCode.NotFound);

            _productSelectiveConstraintsRepository.Delete(stringConstraint);
            _unitOfWork.Commit();

            return new ServiceResult<ProductSelectiveConstraintViewModel>(_mapper.Map<ProductSelectiveConstraintViewModel>(stringConstraint));
        }



        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductSelectiveConstraintsRepository _productSelectiveConstraintsRepository;
    }
}
