using System;

namespace Diba.Core.AppService.Contract
{
    public class ReceiptViewModel
    {
        [DisplayHeader("شناسه", View.Grid)]
        public long Id { get; set; }

        [DisplayHeader("مشتری", View.Both)]
        public string CustomerFullName { get; set; }

        [DisplayHeader("مسئول جمع آوری", View.Form)]
        public string CollectorFullName { get; set; }

        [DisplayHeader("مسئول پخش", View.Form)]
        public string DeliveryFullName { get; set; }

        [DisplayHeader("منشی", View.Both)]
        public string SecretaryFullName { get; set; }

        [DisplayHeader("وضعیت", View.Both)]
        public ReceiptState State { get; set; }

        [DisplayHeader("موعد جمع آوری", View.Form)]
        public DateTime? CollectingDueDate { get; set; }

        [DisplayHeader("موعد تحویل", View.Form)]
        public DateTime? DeliveringDueDate { get; set; }
    }
}
