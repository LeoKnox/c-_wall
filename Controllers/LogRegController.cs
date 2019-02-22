using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using the_wall.Models;

namespace the_wall.Controllers
{
    public class LogRegController : Controller
    {
        private the_wallContext dbContext;

        public LogRegController(the_wallContext context)
        {
            dbContext = context;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [RouteAttribute("createuser")]
        [HttpPost]
        public IActionResult CreateUser(User newUser)
        {
            if (ModelState.IsValid)
            {
                dbContext.CreateUser(newUser, HttpContext);
                return RedirectToAction("DashBoard", "Wall");
            }
            else
            {
                return View("Index");
            }
        }

        [RouteAttribute("loginuser")]
        [HttpPost]
        public IActionResult LoginUser(Login newLogin)
        {
            if (ModelState.IsValid)
            {
                dbContext.LoginUser(newLogin, HttpContext);
                return RedirectToAction("DashBoard", "Wall");
            }
            else
            {
                return View("Index");
            }
        }
    }
}
