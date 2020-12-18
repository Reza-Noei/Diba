namespace Diba.Core.AppService.Contract
{
    public interface IInvoicesQueryService
    {
        InvoiceViewModel Get(long id);
        InvoiceCollectionViewModel List(QueryInvoicesInputModel request);
    }
}
