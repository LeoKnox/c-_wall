using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace the_wall.Models
{
    public class User
    {
       [Key]
       public int UserId {get; set;}
       [Required]
       [MinLength(2)]
       [Display(Name = "First Name")]
       public string FirstName {get; set;}
       [Required]
       [MinLength(2)]
       [Display(Name = "Last Name")]
       public string LastName {get; set;}
       [Required]
       [EmailAddress]
       [Display(Name = "Email Address")]
       public string Email {get; set;}
       [DataType(DataType.Password)]
       [Required]
       [MinLength(8, ErrorMessage=" Must be at least 8 characters")]
       public string Password{get; set;}

       [NotMapped]
       [Compare("Password")]
       [Display(Name = "Confirm Password")]
       [DataType(DataType.Password)]
       public string cPassword {get; set;}
       
       public DateTime CreatedAt {get;set;}
       public DateTime UpdatedAt {get;set;}

       public int CommentId {get; set;}
       public int MessageId {get; set;}
       public List<Message> CreatedMessages {get; set;}
       public List<Comment> CreatedComments {get; set;}
    }
}