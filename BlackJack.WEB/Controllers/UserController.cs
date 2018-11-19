using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Infrastructure;
using BlackJack.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BlackJack.WEB.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
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
        public ActionResult CreateUser(SubmitUserHomeView user)
        {
            try
            {
                long currentuserid = _userService.CreateUser(user);

                return RedirectToAction("Process", "Game", new { id = currentuserid });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult AllUsers()
        {
            AllUsersUserView item = _userService.AllUsers();
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