using System;

namespace Marina_Club.Command.UpdateCommand
{
    public class UpdateAboutUsCommand
    {
        public Guid AboutUsId { get; set; }

        public string NewTextAboutUs { get; set; }
    }
}
