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
    public class UserController : Controller
    {
        IUserService userService;
        ICardService cardService;

        public UserController(IUserService userService, ICardService cardService)
        {
            this.userService = userService;
            this.cardService = cardService;
        }


        // GET: Game

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SubmitNewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveUser(UserViewModel user)
        {
            try
            {
                UserViewModel tmpUser = new UserViewModel() { Name = user.Name };
                userService.CreateUser(tmpUser);

                return RedirectToAction("AllUsers");
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