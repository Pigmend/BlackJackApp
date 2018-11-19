using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Infrastructure;
using BlackJack.ViewModels;

namespace BlackJack.WEB.Controllers
{
    public class HomeController : Controller
    {
        IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Submit()
        {
            SubmitUserHomeView item = _userService.Submit();
            return View(item);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}