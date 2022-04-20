using System;

namespace Marina_Club.Command.SiteManagerCommand
{
    public class AddIntroducingCommand
    {
        public string IntroducingText { get; set; }
        
        public string NameFileIntroducing { get; set; }
        
        public string pathFileIntroducing { get; set; }
        
        public Guid WaterFunIntroducing { get; set; }//مشخص کردن نوع تفریح برای معرفی تفریحات
    }
}
