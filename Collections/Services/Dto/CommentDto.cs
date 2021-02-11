using System;
using Services.Abstractions.Interfaces;

namespace Services.Dto
{
    public class CommentDto : BaseDto
    {
        public string Text { get; set; }
        
        public DateTime Date { get; set; }
        
        public UserDto Sender { get; set; }
        
        public int ItemId { get; set; }
    }
}