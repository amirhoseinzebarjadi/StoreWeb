using System;
using System.ComponentModel.DataAnnotations;

namespace Marina_Club.Model
{
    public class Sans
    {
        [Key]
        public Guid SansId { get; set; }

        public Guid WaterFunId { get; set; }

        public int SoldTicketOnline { get; set; }

        public  int SoldTicketPerson { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsEnable { get; set; }

        public DateTime Date { get; set; }

        public bool IsCancel { get; set; }

        public TimeSpan StartTimeSans { get; set; }

        public int SalesCapacityPerson { get; set; }

        public int SalesCapacityOnline { get; set; }

        public int Capacity { get; set; }

        public double Price { get; set; }

        public  WaterFun WaterFunIdForDto { get; set; }
        
    }
}
