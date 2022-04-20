

using System;

namespace Marina_Club.Command.WaterFunCommand
{
    public class DiscountCommand
    {
        public string FunType { get; set; }
        
        public double DiscountAmount { get; set; }
        
        public DateTime StartDiscount { get; set; }
        
        public DateTime EndDiscount { get; set; }
        
        public int FinalPrice { get; set; }
    }
}
