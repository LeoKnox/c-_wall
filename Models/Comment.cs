using System;
using System.ComponentModel.DataAnnotations;

namespace the_wall.Models
{
    public class Comment
    {
        [Key]
        public int CommentId {get; set;}
        public string MyComment {get; set;}
        public DateTime Created_At {get; set;}
        public DateTime Updated_At {get; set;}

        public int UserId {get; set;}
        public User Commenter {get; set;}
        public int MessageId {get; set;}
        public Message Messanger {get; set;}
    }
}