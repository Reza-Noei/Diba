using System;

namespace Diba.Core.AppService.Contract
{
    //public class CreateCustomerInputModel
    //{
    //    public string Code { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string District { get; set; }
    //    public string Description { get; set; }        
    //    public string EconomicCode { get; set; }
    //    public string PostalCode { get; set; }
    //    public string NationalIdentifier { get; set; }
    //    public string RegistrationNumber { get; set; }
    //    public ContactInfoInputModel ContactInfo { get; set; }
    //}

    public class DeleteCustomerInputModel
    {
        public int Id { get; set; }
    }
    public class UpdateCustomerInputModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class CreateCustomerInputModel
    {
        public long OrganizationId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Code { get; set; }

        public string District { get; set; }

        public string Description { get; set; }

        public DateTime BirthDate { get; set; }

        public string EconomicCode { get; set; }

        public string PostalCode { get; set; }

        public string NationalIdentifier { get; set; }

        public string RegistrationNumber { get; set; }
    }

    public class ContactInfoInputModel
    {
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
