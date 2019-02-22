
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using the_wall.Models;

namespace the_wall.Controllers
{
    public class WallController : Controller
    {
        private the_wallContext dbContext;

        public WallController(the_wallContext context)
        {
            dbContext = context;
        }

        [Route("dashboard")]
        [HttpGet]
        public IActionResult DashBoard()
        {
            int? userid = HttpContext.Session.GetInt32("uid");
            User currentUser = dbContext.Users
                .Where(u => u.UserId == userid)
                .Include(m => m.CreatedMessages)
                .FirstOrDefault();
            List<Message> currentMessages = dbContext.Messages.ToList();
            Dashboard myDash = new Dashboard();
            myDash.OneUser = currentUser;
            myDash.Messages = currentMessages;
            return View("Index", myDash);
        }

        [Route("postmessage")]
        [HttpPost]
        public IActionResult PostMessage(Message newMessage)
        {
            int? x = HttpContext.Session.GetInt32("uid");
            newMessage.UserId = (int)x;
            newMessage.CreatedAt = DateTime.Now;
            newMessage.UpdatedAt = DateTime.Now;
            dbContext.Add(newMessage);
            dbContext.SaveChanges();
            return RedirectToAction("dashboard");
        }
    }
}