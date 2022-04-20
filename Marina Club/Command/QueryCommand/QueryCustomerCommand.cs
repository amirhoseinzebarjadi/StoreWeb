namespace Marina_Club.Command.QueryCommand
{
    public class QueryCustomerCommand
    {
        public  string SearchWord { get; set; }
        
        public int PageNumber { get; set; }
        
        public int PageSize { get; set; }
    }
}
