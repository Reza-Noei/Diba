namespace Diba.Core.AppService.Contract
{
    public interface IQuickAccessListQuery
    {
        ServiceResult<QuickAccessListViewModel> Get(QuickAccessListType ListType);
    }
}
