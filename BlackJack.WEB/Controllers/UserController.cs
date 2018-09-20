using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.BusinessLogicLayer.Infrastructure;
using BlackJack.ViewModels.EntityViewModel;
using BlackJack.ViewModels.Response;

namespace BlackJack.WEB.Controllers
{
    public class UserController : Controller
    {
        IUserService userService;
        ICardService cardService;

        public UserController(IUserService userService, ICardService cardService)
        {
            this.userService = userService;
            this.cardService = cardService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SubmitNewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveUser(GameSubmitNewUser user)
        {
            try
            {
                int currentUserID = userService.CreateUser(user);
                return RedirectToAction("GameTable", "Game", new { ID = currentUserID });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult AllUsers()
        {
            return View(userService.GetUsers());
        }

        public ActionResult SelectUser(int id)
        {
            return RedirectToAction("GameTable", "Game", new { ID = id });
        }

        public ActionResult DeleteUser(int id)
        {
            userService.DeleteUser(id);
            return RedirectToAction("AllUsers");
        }

        public ActionResult CardTable()
        {
            return View(cardService.GetAllCards());
        }
    }
}