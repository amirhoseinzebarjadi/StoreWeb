using System.ComponentModel;

namespace Marina_Club.Model
{
    public enum ESoldType
    {

        [Description("آنلاین/کاربر")]
        SoldCustomer = 1,

        [Description("آنلاین/فروشنده")]
        SoldSeller = 2,

        [Description("آنلاین/کانتر")]
        SoldSellerCounter = 3,
    }
}