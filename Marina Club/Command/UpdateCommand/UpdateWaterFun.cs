using System;
using Marina_Club.Command.WaterFunCommand;

namespace Marina_Club.Command.UpdateCommand
{
    public class UpdateWaterFun
    {
        public Guid Id { get; set; }
        
        public string FunType { get; set; }
        
        public DiscountCommand Discounts { get; set; }
        
        public double Price { get; set; }
        
        public int DurationMinutes { get; set; }
        
        public int GapMinutes { get; set; }
        
        public TimeSpan StartTimeWork { get; set; }
        
        public TimeSpan EndTimeWork { get; set; }
        
        public bool IsActiveWaterFun { get; set; }
        
        public int SalesCapacityPerson { get; set; }
        
        public int SalesCapacityOnline { get; set; }
        
        public int Capacity { get; set; }
    }
}
