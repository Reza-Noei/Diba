using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.ProductConstraint;
using Diba.Core.AppService.Contract.ProductConstraint.Model.ViewModel;
using Diba.Core.AppService.Contract.ProductStringConstraint.Model.InputModel;
using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain.Products.ProductConstraints;

namespace Diba.Core.AppService.Products
{
    public class ProductStringConstraintsCommandService : IProductStringConstraintsCommandService
    {
        public ProductStringConstraintsCommandService(IMapper mapper, IUnitOfWork unitOfWork, IProductStringConstraintsRepository productStringConstraintsRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productStringConstraintsRepository = productStringConstraintsRepository;
        }

        public ServiceResult<ProductStringConstraintsViewModel> Create(int productId, CreateProductStringConstraintsViewModel request)
        {
             var stringConstraint = _mapper.Map<StringConstraint>(request);
            stringConstraint.ProductId = productId;
            _productStringConstraintsRepository.Add(stringConstraint);
            _unitOfWork.Commit();

            return new ServiceResult<ProductStringConstraintsViewModel>(_mapper.Map<ProductStringConstraintsViewModel>(stringConstraint));

        }

        public ServiceResult<ProductStringConstraintsViewModel> Update(int productId, int constraintId, UpdateProductStringConstraintsViewModel request)
        {
            StringConstraint stringConstraint = _productStringConstraintsRepository.GetById(constraintId);

            if (stringConstraint == null)
                return new ServiceResult<ProductStringConstraintsViewModel>(StatusCode.NotFound);

            stringConstraint.Update(title: request.Title, format: request.Format, maxLength: request.MaxLength);
            _productStringConstraintsRepository.Update(stringConstraint);
            _unitOfWork.Commit();

            return new ServiceResult<ProductStringConstraintsViewModel>(_mapper.Map<ProductStringConstraintsViewModel>(stringConstraint));
        }

        public ServiceResult<ProductStringConstraintsViewModel> Delete(int id)
        {
            StringConstraint stringConstraint = _productStringConstraintsRepository.GetById(id);

            if (stringConstraint == null)
                return new ServiceResult<ProductStringConstraintsViewModel>(StatusCode.NotFound);

            _productStringConstraintsRepository.Delete(stringConstraint);
            _unitOfWork.Commit();

            return new ServiceResult<ProductStringConstraintsViewModel>(_mapper.Map<ProductStringConstraintsViewModel>(stringConstraint));
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductStringConstraintsRepository _productStringConstraintsRepository;
    }
}
