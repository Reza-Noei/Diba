namespace Diba.Core.AppService.Contract
{
    public class CustomerViewModel
    {
        [DisplayHeader("شناسه", View.Form)]
        public long Id { get; set; }

        [DisplayHeader("کد مشتری", View.Both)]
        public string Code { get; set; }

        [DisplayHeader("نام", View.Both)]
        public string FirstName { get; set; }

        [DisplayHeader("نام خانوادگی", View.Both)]
        public string LastName { get; set; }

        [DisplayHeader("محله", View.Both)]
        public string District { get; set; }

        [DisplayHeader("شماره تماس", View.Both)]
        public string PhoneNumber { get; set; }

        [DisplayHeader("آدرس", View.Both)]
        public string Address { get; set; }

        [DisplayHeader("کد اقتصادی", View.Form)]
        public string EconomicCode { get; set; }

        [DisplayHeader("کد پستی", View.Form)]
        public string PostalCode { get; set; }

        [DisplayHeader("شناسه ملی", View.Form)]
        public string NationalIdentifier { get; set; }

        [DisplayHeader("شماره ثبت", View.Form)]
        public string RegistrationNumber { get; set; }
    }
}
