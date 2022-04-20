using System;

namespace Marina_Club.Command.UpdateCommand
{
    public class UpdateRulesCommand
    {
        public Guid RulesId { get; set; }
        
        public string NewTextRules { get; set; }
    }
}
