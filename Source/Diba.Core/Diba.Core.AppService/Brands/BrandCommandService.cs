using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.Brands;
using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;

namespace Diba.Core.AppService.Brands
{
    public class BrandCommandService : IBrandCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;

        public BrandCommandService(IUnitOfWork unitOfWork, IMapper mapper, IBrandRepository brandRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        public ServiceResult<BrandViewModel> Create(CreateBrandInputModel request)
        {
            var brand = _mapper.Map<Brand>(request);
            _brandRepository.Add(brand);
            _unitOfWork.Commit();

            return new ServiceResult<BrandViewModel>(_mapper.Map<BrandViewModel>(brand));
        }

        public ServiceResult<BrandViewModel> Update(long id, UpdateBrandInputModel request)
        {
            Brand brand = _brandRepository.GetById(id);

            if (brand == null)
                return new ServiceResult<BrandViewModel>(StatusCode.NotFound);

            _brandRepository.Update(brand);
            _unitOfWork.Commit();

            return new ServiceResult<BrandViewModel>(_mapper.Map<BrandViewModel>(brand));
        }

        public ServiceResult<BrandViewModel> Delete(long id)
        {
            Brand brand = _brandRepository.GetById(id);

            if (brand == null)
                return new ServiceResult<BrandViewModel>(StatusCode.NotFound);

            _brandRepository.Delete(brand);
            _unitOfWork.Commit();

            return new ServiceResult<BrandViewModel>(_mapper.Map<BrandViewModel>(brand));
        }
    }
}