namespace Diba.Core.AppService
{
    public class CreateCustomerInputModel
    {
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string District { get; set; }
        public string Description { get; set; }        
        public string EconomicCode { get; set; }
        public string PostalCode { get; set; }
        public string NationalIdentifier { get; set; }
        public string RegistrationNumber { get; set; }
        public ContactInfoInputModel ContactInfo { get; set; }
    }

    public class ContactInfoInputModel
    {
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
