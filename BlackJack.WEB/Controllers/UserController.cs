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
                UserDTO tmpUser = new UserDTO() { Name = user.Name };
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
            IEnumerable<UserDTO> userDTOs = userService.GetUsers();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var users = mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userDTOs);

            return View(users);
        }

        public ActionResult DeleteUser(int id)
        {

            userService.DeleteUser(id);

            return RedirectToAction("AllUsers");
        }

        public ActionResult CardTable()
        {
            IEnumerable<CardDTO> cardDTOs = cardService.GetAllCards();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CardDTO, CardViewModel>()).CreateMapper();
            var cards = mapper.Map<IEnumerable<CardDTO>, List<CardViewModel>>(cardDTOs);

            return View(cards);
        }
    }
}