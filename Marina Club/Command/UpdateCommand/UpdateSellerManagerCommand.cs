using System;

namespace Marina_Club.Command.UpdateCommand
{
    public class UpdateSellerManagerCommand
    {
        public Guid SellerManagerId { get; set; }
        
        public  UpdateSellerInfoCommand UpdateSellerInfoCommand { get; set; }
        
        public UpdateSellerAddressCommand UpdateSellerAddressCommand { get; set; }
        
        public int NewDiscountSeller { get; set; }
        
        public int NewSellerCode { get; set; }
    }
}
