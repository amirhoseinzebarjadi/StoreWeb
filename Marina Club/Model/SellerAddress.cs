using System;
using System.ComponentModel.DataAnnotations;

namespace Marina_Club.Model
{
    public class SellerAddress
    {
        [Key]
        public Guid SellerAddressId { get; set; }
        public string CityNameSeller { get; set; }
        public string CompanyAddress { get; set; }
        public string PostalCodeSeller { get; set; }
    }
}