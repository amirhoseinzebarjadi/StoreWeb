using System;

namespace Marina_Club.Model
{
    public class Customer
    {
        public Customer(string firstNameAndLastName, string nationalCode, string cellPhoneNumber, string phoneNumber, string cardNumber, string cityNameCustomer, string email, string postalCodeCustomer)
        {
                CustomerId = Guid.NewGuid();
                FirstNameAndLastName = firstNameAndLastName;
                NationalCode = nationalCode;
                CellPhoneNumber = cellPhoneNumber;
                PhoneNumber = phoneNumber;
                CardNumber = cardNumber;
                CityNameCustomer = cityNameCustomer;
                Email = email;
                PostalCodeCustomer = postalCodeCustomer;
        }


        public Guid CustomerId { get; set; }
        //public bool IsActiveCustomer  { get; set; }
        public string FirstNameAndLastName { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public string CardNumber { get; set; }
        public string Email { get; set; }
        public string CityNameCustomer { get; set; }
        public string PostalCodeCustomer { get; set; }
    }
}
