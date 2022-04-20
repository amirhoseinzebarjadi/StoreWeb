using System;
using System.ComponentModel.DataAnnotations;

namespace Marina_Club.Model
{
    public class DuplicateQuestions
    {
        [Key]
        public Guid DuplicateQuestionsId { get; set; }
        public string TextDuplicateQuestions { get; set; }
    }
}
