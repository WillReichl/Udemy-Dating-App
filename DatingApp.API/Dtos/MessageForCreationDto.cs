using System;

namespace DatingApp.API.Dtos
{
    public class MessageForCreationDto
    {
        public MessageForCreationDto()
        {
            MessageSent = DateTime.Now;
        }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string SenderKnownAs { get; set; } // naming convention here will help automapper map by convention Sender.KnownAs
        public string SenderPhotoUrl { get; set; }
        public DateTime? MessageSent { get; set; }
        public string Content { get; set; }

    }
}