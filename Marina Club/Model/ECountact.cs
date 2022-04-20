using System.ComponentModel;
namespace Marina_Club.Model
{
    public enum ECountact
    {
        [Description("کاربران")]
        CustomerCountact = 1,

        [Description("فروشندگان")]
        SellerCountact = 2,

        [Description("کاربران و فروشندگان")]
        AllCountact = 3,
    }
}
