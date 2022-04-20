using System;
using System.ComponentModel.DataAnnotations;

namespace Marina_Club.Model
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        public Guid  FunTypeId { get; set; }
        public string UserName { get; set; } 
        public  DateTime CommentTime { get; set; }
        public string TextComment { get; set; }
        public  bool IsConfirmComment { get; set; }
        //##
        public int Like { get; set; }
        public int DisLike { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }
       
    }
}
