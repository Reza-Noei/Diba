namespace Diba.Core.AppService.Contract
{
    public class ReceiptItemViewModel
    {
        [DisplayHeader("شرح", View.Both)]
        public string Description { get; set; }
    }
}
