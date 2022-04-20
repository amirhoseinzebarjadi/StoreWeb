using System;
using System.ComponentModel.DataAnnotations;

namespace Marina_Club.Model
{
    public class SellerMessage
    {
        [Key]
        public Guid SellerMessages { get; set; }
        public  int PhoneNumberSellerForMessage { get; set; }
        public  string NameSellerForMessage { get; set; }
    }
}
