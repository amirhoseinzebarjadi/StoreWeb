using System;

namespace Marina_Club.Command.WaterFunCommand
{
    public class UpdateWaterFunSansCommand
    {
        public bool IsEnable { get; set; }
        
        public bool IsCancel { get; set; }
        
        public Guid SansId { get; set; }
    }
}
