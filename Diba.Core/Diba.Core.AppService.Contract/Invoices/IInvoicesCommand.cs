namespace Diba.Core.AppService.Contract
{
    public interface IInvoicesCommandService
    {
        ServiceResult<InvoiceViewModel> Create(CreateInvoiceInputModel request);
        ServiceResult<InvoiceViewModel> Update(long id, UpdateInvoiceInputModel request);
        ServiceResult<InvoiceViewModel> Delete(long id);
    }
}
