namespace Marina_Club.Command.WaterFunCommand
{
    public class AddWaterFunCommand
    {
        public string FunType { get; set; }
        
        public DiscountCommand Discounts { get; set; }
        
        public double Price { get; set; }
        
        public int DurationMinutes { get; set; }
        
        public int GapMinutes { get; set; }
        
        public string StartTimeWork { get; set; }
        
        public string EndTimeWork { get; set; }
        
        public bool IsActiveWaterFun { get; set; }
        
        public int SalesCapacityPerson { get; set; }
        
        public int SalesCapacityOnline { get; set; }
        
        public int Capacity { get; set; }

    }
}
