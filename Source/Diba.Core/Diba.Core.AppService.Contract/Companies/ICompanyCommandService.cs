namespace Diba.Core.AppService.Contract.Companies
{
    public interface ICompanyCommandService
    {
        ServiceResult<CompanyViewModel> Create(CreateCompanyInputModel request);

        ServiceResult<CompanyViewModel> Update(long id, UpdateCompanyInputModel request);

        ServiceResult<CompanyViewModel> Delete(long id);

    }
}