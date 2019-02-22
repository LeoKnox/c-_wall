using System.Collections.Generic;
using the_wall.Models;

namespace the_wall
{
    public class Dashboard
    {
        public User OneUser {get; set;}
        public Message NewMessage {get; set;}
        public List<Message> Messages {get; set;}
    }
}