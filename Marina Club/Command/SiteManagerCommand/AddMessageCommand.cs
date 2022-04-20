using System;
using System.Collections.Generic;

namespace Marina_Club.Command.SiteManagerCommand
{
    public class AddMessageCommand
    {
        public Guid MessageId { get; set; }
        
        public string TextMessage { get; set; }
        
        public List<ListMessageCommand> ListMessageCommands { get; set; }
    }

   
}
