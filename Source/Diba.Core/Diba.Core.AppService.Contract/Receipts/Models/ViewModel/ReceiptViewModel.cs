using System;
using System.Collections.Generic;

namespace Diba.Core.AppService.Contract
{
    public class ReceiptViewModel
    {
        [DisplayHeader("شناسه", View.Grid)]
        public long Id { get; set; }

        [DisplayHeader("تاریخ ثبت", View.Both)]
        public DateTime ReceptionDate { get; set; }

        [DisplayHeader("شناسه مشتری", View.Grid)]
        public long CustomerId { get; set; }

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

        [DisplayHeader("مبلغ برآورد شده", View.Form)]
        public DateTime? EstimatedPrice { get; set; }

        [DisplayHeader("موعد تحویل", View.Form)]
        public DateTime? DeliveringDueDate { get; set; }

        [DisplayHeader("اقلام", View.None)]
        public IEnumerable<ReceiptItemViewModel> Items { get; set; }
    }
}
