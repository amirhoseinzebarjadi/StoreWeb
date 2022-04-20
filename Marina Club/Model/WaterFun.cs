using System;
using System.ComponentModel.DataAnnotations;

namespace Marina_Club.Model
{
    public class WaterFun
    {
        [Key]
        public Guid Id { get; set; }
        public string FunType { get; set; }
        public Discount Discounts { get; set; }
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
