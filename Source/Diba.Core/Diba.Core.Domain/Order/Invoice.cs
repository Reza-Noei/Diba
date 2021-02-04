using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Domain
{
    public class Invoice
    {
        public long Id { get; set; }

        public string SerialNumber { get; set; }
        public virtual ICollection<CustomerOrder> Orders { get; set; }

        /// <summary>
        /// پیش پرداخت
        /// </summary>
        public decimal EarnestMoney { get; set; }

        public DateTime Reception { get; set; }

        public InvoiceState State { get; set; }

        public Invoice()
        {
            Reception = DateTime.UtcNow;
            Orders = new HashSet<CustomerOrder>();
        }
    }

    public enum InvoiceState
    {
        Reception = 1,
        Scheduled = 2,
        Collected = 3, 
        OnService = 4,
        Delivered = 5,
        Settlement = 6
    }
}
