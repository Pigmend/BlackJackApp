using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.BusinessLogicLayer.Infrastructure;
using BlackJack.ViewModels.Game;
using BlackJack.ViewModels.Response;

namespace BlackJack.WEB.Controllers
{
    public class GameController : Controller
    {
        IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public ActionResult GameTable(int currentUserID)
        {
            GameDataViewModel model = gameService.GetDataForGame(currentUserID);
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveChanges(int gameID)
        {

            return RedirectToAction("ContinueGame", new { ID = gameID });
        }

        public ActionResult ContinueGame(int gameID)
        {

            return View();
        }
    }
}