using System;

namespace Marina_Club.Dto
{
    public class FunTypeDto
    {
        public Guid  Id { get; set; }
        public Guid FunType { get; set; }
        public TimeSpan StartTimeSans { get; set; }
        public TimeSpan EndTimeSans { get; set; }
        public DateTime Date { get; set; }
    }
}
