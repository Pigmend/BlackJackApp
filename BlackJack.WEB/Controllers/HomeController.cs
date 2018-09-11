using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Infrastructure;
using BlackJack.ViewModels;
using BlackJack.BLL.DTO;
using AutoMapper;

namespace BlackJack.WEB.Controllers
{
    public class HomeController : Controller
    {
        IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My contacts:";

            return View();
        }
    }
}