using System.ComponentModel;

namespace Marina_Club.Model
{
    public enum ETitleOfSuggestion
    {
        [Description("پرفروش ها")]
        BestSellers = 1,

        [Description("تخفیف دار ها")]
        Discounted = 2,

        [Description("پر طرفدار ها")]
        Popular = 3,
    }
}