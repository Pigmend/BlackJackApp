using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Infrastructure;
using BlackJack.ViewModels.Response;
using BlackJack.ViewModels.Request;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.WEB.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService, IDeckService cardService)
        {
            this._userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SubmitNewUser()
        {
            UserCreateUserViewModel item = new UserCreateUserViewModel();
            return View(item);
        }

        [HttpPost]
        public ActionResult CreateUser(UserCreateUserViewModel user)
        {
            try
            {
                long currentUserID = _userService.CreateUser(user);
                // Change ...
                return RedirectToAction("Process", "Game", new { ID = currentUserID });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult AllUsers()
        {
            UserAllUsersViewModel item = _userService.GetUsers();
            return View(item);
        }

        public ActionResult SelectUser(long UserId)
        {
            return RedirectToAction("Process", "Game", new { id = UserId });
        }

        public ActionResult DeleteUser(long UserId)
        {
            _userService.DeleteUser(UserId);
            return RedirectToAction("AllUsers");
        }
    }
}