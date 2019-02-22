using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace the_wall.Models
{
    public class the_wallContext : DbContext
    {
        public the_wallContext(DbContextOptions<the_wallContext> options) : base(options) {}
        public DbSet<User> Users {get; set;}
        public DbSet<Login> Loggers {get; set;}
        public DbSet<Message> Messages {get; set;}
        public DbSet<Comment> Comments {get; set;}
        
        public void CreateUser(User newUser, HttpContext context)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            newUser.CreatedAt = DateTime.Now;
            newUser.UpdatedAt = DateTime.Now;
            Add(newUser);
            SaveChanges();
            User oneUser = Users.Last();
            int x = oneUser.UserId;
            context.Session.SetInt32("uid", x);
        }

        public void LoginUser(Login newLogin, HttpContext context)
        {
            User oneUser = Users
                .FirstOrDefault(log => log.Email == newLogin.lemail);
            var hasher = new PasswordHasher<Login>();
            var result = hasher.VerifyHashedPassword(
                newLogin, oneUser.Password, newLogin.lpassword);
            context.Session.SetInt32("uid", oneUser.UserId);
        }
    }
}