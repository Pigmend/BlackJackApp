using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Infrastructure;
using BlackJack.ViewModels;
using BlackJack.ViewModels.Response;

namespace BlackJack.WEB.Controllers
{
    public class HomeController : Controller
    {
        IUserService _userService;

        public HomeController(IUserService userService)
        {
            this._userService = userService;
        }

        public ActionResult Index()
        {
            ResponseSubmitUserHomeViewModel item = _userService.Index();
            return View(item);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}