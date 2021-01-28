using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Contract
{
    public class InvoiceShortViewModel
    {
        [DisplayHeader("شناسه", View.Grid)]
        public long Id { get; set; }

        [DisplayHeader("شماره فاکتور", View.Grid)]
        public string InvoiceNumber { get; set; }

        [DisplayHeader("تاریخ ثبت", View.Both)]
        public DateTime Creation { get; set; }

        [DisplayHeader("مشتری", View.Both)]
        public string Customer { get; set; }

        [DisplayHeader("مسئول ثبت", View.Both)]
        public string Secretary { get; set; }
    }

    public class InvoiceViewModel
    {
        public long Id { get; set; }
        public string Exporter { get; set; }
        public DateTime ExportedAt { get; set; }
        public Decimal TotalPrice { get; set; }

        public IEnumerable<InvoiceItemViewModel> Items { get; set; }
    }

    public class InvoiceItemViewModel
    {
        [DisplayHeader("شناسه", View.Both)]
        public long Id { get; set; }

        [DisplayHeader("محصول", View.Both)]
        public string Title { get; set; }

        [DisplayHeader("واحد اندازه گیری", View.Both)]
        public string Unit { get; set; }

        [DisplayHeader("مقدار", View.Both)]
        public int Count { get; set; }

        [DisplayHeader("قیمت واحد", View.Both)]
        public decimal UnitPrice { get; set; }

        [DisplayHeader("قیمت کل", View.Both)]
        public decimal TotalPrice { get; set; }
    }
}
