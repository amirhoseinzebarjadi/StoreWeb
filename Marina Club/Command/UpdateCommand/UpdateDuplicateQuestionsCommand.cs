using System;

namespace Marina_Club.Command.UpdateCommand
{
    public class UpdateDuplicateQuestionsCommand
    {
        public Guid DuplicateQuestionsId { get; set; }
        
        public string NewTextDuplicateQuestions { get; set; }
    }
}
