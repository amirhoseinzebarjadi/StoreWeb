using System;
using System.ComponentModel.DataAnnotations;

namespace Marina_Club.Model
{
    public class Discount
    {
        [Key]
        public Guid Id { get; set; }
        public string FunType { get; set; }
        public double DiscountAmount { get; set; }
        public DateTime StartDiscount { get; set; }
        public DateTime EndDiscount { get; set; }
        public int FinalPrice { get; set; }
    }
}
