using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Infrastructure;
using BlackJack.ViewModels.Game;
using BlackJack.ViewModels.Response;

namespace BlackJack.WEB.Controllers
{
    public class GameController : Controller
    {
        private IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public ActionResult Process(long id)
        {
            GameProcessViewModel newGameView = _gameService.GetGameData(id);
            return View(newGameView);
        }

        [HttpPost]
        public JsonResult SaveChanges(string order)
        {
            //... TO DO
            return Json("OK");
        }

        public ActionResult ContinueGame(int gameID)
        {
            //... TO DO
            return View();
        }
    }
}