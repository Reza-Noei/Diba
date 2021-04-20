namespace Diba.Core.AppService.Contract.Brands
{
    public interface IBrandCommandService
    {
        ServiceResult<BrandViewModel> Create(CreateBrandInputModel request);

        ServiceResult<BrandViewModel> Update(long id, UpdateBrandInputModel request);

        ServiceResult<BrandViewModel> Delete(long id);

    }
}