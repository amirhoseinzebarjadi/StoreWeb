namespace Marina_Club.Command.QueryCommand
{
    public class QuerySansInCounterCommand
    {
        public string SearchWordFunSansTypeCounter { get; set; }//برای جست و جوی سانس ها ی مورد نظر
        
        public string SearchWordDateSansCounter { get; set; }//برای جست و جوی سانس های مورد نظر
        
        public int PageNumber { get; set; }
        
        public int PageSize { get; set; }
    }
}
