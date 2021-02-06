namespace Diba.Core.Domain
{
    public class CustomerOrder
    {
        public long Id { get; set; }

        /// <summary>
        /// شرح کالا یا خدمات
        /// </summary>
        public string ServiceDescription { get; set; }

        /// <summary>
        /// نوع کالا یا خدمت
        /// </summary>
        public virtual QName ServiceType { get; set; }
        public long ServiceTypeId { get; set; }

        /// <summary>
        /// تعداد
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// واحد اندازه گیری
        /// </summary>
        public virtual QName Unit { get; set; }
        public long UnitId { get; set; }

        /// <summary>
        /// مبلغ واحد (Rials)
        /// </summary>
        public decimal PricePerUnit { get; set; }

        /// <summary>
        /// مبلغ کل (Rials)
        /// </summary>
        public decimal TotalPrice => PricePerUnit * Count;

        /// <summary>
        /// تخفیف (Rials)
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// مبلغ کل پس از تخفیف (Rials)
        /// </summary>
        public decimal TotalPriceAfterApplyingDiscount => TotalPrice - Discount;

        /// <summary>
        /// مالیات و عوارض (Rials)
        /// </summary>
        public decimal Tax { get; set; }

        /// <summary>
        /// مبلغ کل پس از اعمال تخفیف و افزودن مالیات و عوارض
        /// </summary>
        public decimal TotalPriceAfterApplyingDiscountAndTax => TotalPriceAfterApplyingDiscount + Tax;

       // public long? DeliveryMembershipId { get; set; }
        //public virtual DeliveryMembership DeliveryMembership { get; set; }

       // public long? CollectorMembershipId { get; set; }
       // public virtual CollectorMembership CollectorMembership { get; set; }

        public PaymentType PaymentType { get; set; }

        public CustomerOrder()
        {

        }
    }
}
