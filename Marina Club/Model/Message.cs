using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Marina_Club.Model
{
    public class Message
    {
        [Key]
        public Guid MessageId { get; set; }
        public string TextMessage { get; set; }
        public DateTime DateMessage { get; set; }//تایم حال باید برای هر پیامک ثبت شود
        public  List<ListMessage> ListMessages { get; set; }
        //public List<SellerMessage> SellerMessages { get; set; }//گرفتن شماره فروشنده برای ارسال پیام با کلیک کردن روی گزینه ها
        //public List<CustomerMessage> CustomerMessages { get; set; }//گرفتن شماره فروشنده برای ارسال پیام با کلیک کردن روی گزینه ها
        ////public ECountact ECountact { get; set; }//همه//کاربران//فروشندگان
    }
}
