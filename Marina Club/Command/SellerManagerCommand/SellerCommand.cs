namespace Marina_Club.Command.SellerManagerCommand
{
    public class SellerCommand
    {
        public  SellerInfoCommand SellerInfoCommand { get; set; }
        
        public  SellerAddressCommand SellerAddressCommand { get; set; }
        
        public int SellerCode { get; set; }
        
        public int DiscountSeller { get; set; }
    }
}
