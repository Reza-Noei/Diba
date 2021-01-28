using System;
using System.Collections.Generic;

namespace Diba.Core.Domain
{
    public class Customer
    {
        public long Id { get; set; }

        public long RoleId { get; set; }

        public virtual BaseRole Role { get; set; }

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

        public long RefererId { get; set; }
        public virtual Organization Referer { get; set; }
        
        public virtual ICollection<ContactInfo> ContactInfos { get; set; }
        public virtual ICollection<CustomerMembership> Memberships { get; set; }

        public Customer()
        {
            Memberships = new HashSet<CustomerMembership>();
            ContactInfos = new HashSet<ContactInfo>();
        }
    }
}
