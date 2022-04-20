using System;
using System.ComponentModel.DataAnnotations;

namespace Marina_Club.Model
{
    public class SellerManager
    {
        [Key]
        public Guid SellerManagerId { get; set; }
        public SellerInfo SellerInfo { get; set; }//اطلاعات آدرس   fk
        public SellerAddress SellerAddress { get; set; }//اطلاعات   fk
        public int DiscountSeller { get; set; }//تخفیف مخصوص هر فروشنده
        public int SellerCode { get; set; }//به عنوان نام کاربری استفاده میشه
    }
}
