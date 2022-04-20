using System;

namespace Marina_Club.Command.UpdateCommand
{
    public class UpdateContactUsCommand
    {
        public Guid ContactUsId { get; set; }
        
        public string NewPhoneMarina { get; set; }
        
        public string NewEmailMarina { get; set; }
        
        public string NewFaxMarina { get; set; }
        
        public string NewAddressMarina { get; set; }
    }
}
