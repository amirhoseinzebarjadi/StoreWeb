using System;
using System.Collections.Generic;
using Marina_Club.Model;

namespace Marina_Club.Dto
{
    public class ReservationDto
    {
        public WaterFun WaterFunId { get; set; }
        public Discount Discounts { get; set; }
        public IList<Sans> Sanses { get; set; }
        public string FunTypes { get; set; }
        public int DurationMinutes { get; set; }
        //قیمت ثبت نشده هنوز
        public int SoldTicket { get; set; }
        public int Capacity { get; set; }
        public bool IsEnable { get; set; }
        public DateTime Date { get; set; }//تاریخ هر سانس //میتون عدد هم باشه 
        public double Price { get; set; }
        public TimeSpan StartTimeSans { get; set; }
        public int EndTimeSans { get; set; }
        public Guid SansId { get; set; }

        public bool IsCancel { get; set; }

        public int SalesCapacityPerson { get; set; }

        public int SalesCapacityOnline { get; set; }


        public WaterFun WaterFunIdForDto { get; set; }
    }
}
