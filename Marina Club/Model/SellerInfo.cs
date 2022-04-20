using System;
using System.ComponentModel.DataAnnotations;

namespace Marina_Club.Model
{
    public class SellerInfo
    {
        [Key]
        public Guid SellerInfoId { get; set; }
        public string FirstNameAndLastNameSeller { get; set; }
        public string CompanyName { get; set; }
        public string NationalCodeSeller { get; set; }
        public string PhoneNumberSeller { get; set; }
        public string CellPhoneNumberseller { get; set; }
        public string CardNumberSeller { get; set; }
        public string  SellerEmail { get; set; }

        ///////////////////////////////////////////////////////آپلود فایل کارت ملی فروشنده
        //public string NationalCardFileSeller { get; set; }//
        //public string FilePathNationalCardFileSeller { get; set; }
    }
}