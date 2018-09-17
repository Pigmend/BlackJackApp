using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.BusinessLogicLayer.Infrastructure;
using BlackJack.ViewModels;

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
    }
}