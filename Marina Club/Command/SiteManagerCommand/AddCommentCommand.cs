using System;

namespace Marina_Club.Command.SiteManagerCommand
{
    public class AddCommentCommand
    {
        public Guid FunTypeId { get; set; }
        
        public string UserName { get; set; }//Dto است و نام کاربر را میگیردو نمایش میدهد
        
        public string TextComment { get; set; }
    }
}
