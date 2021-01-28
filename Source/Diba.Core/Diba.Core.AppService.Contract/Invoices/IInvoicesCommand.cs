namespace Diba.Core.AppService.Contract
{
    public interface IInvoicesCommandService
    {
        ServiceResult<InvoiceShortViewModel> Create(CreateInvoiceInputModel request);
        ServiceResult<InvoiceShortViewModel> Update(long id, UpdateInvoiceInputModel request);
        ServiceResult<InvoiceShortViewModel> Delete(long id);
    }
}
