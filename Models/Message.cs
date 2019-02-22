using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace the_wall.Models
{
    public class Message
    {
        [Key]
        public int MessageId {get; set;}
        [Required]
        [Display(Name = "Post a Message")]
        public String MyMessage {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public int UserId {get; set;}
        public User Creator {get; set;}
        public List<Comment> MadeComments {get; set;}
    }
}