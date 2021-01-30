using System;

namespace Diba.Core.Domain
{

    public class Customer: Role
    {
        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string District { get; set; }

        public string Description { get; set; }

        public DateTime BirthDate { get; set; }

        /// <summary>
        /// کد اقتصادی
        /// </summary>
        public string EconomicCode { get; set; }

        /// <summary>
        /// کد پستی
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// شناسه ملی
        /// </summary>
        public string NationalIdentifier { get; set; }

        /// <summary>
        /// شماره ثبت
        /// </summary>
        public string RegistrationNumber { get; set; }

        public long OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }
        
        
        public Customer()
        {

        }
    }
}
