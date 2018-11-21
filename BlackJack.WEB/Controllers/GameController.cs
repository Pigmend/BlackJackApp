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
    public class GameController : Controller
    {
        private IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public ActionResult Process(long id)
        {
            ProcessGameView newGameView = _gameService.GetGameData(id);
            return View(newGameView);
        }

        // TO DO
        public ActionResult StartRound(ProcessGameView model)
        {
            ProcessGameView step = _gameService.StartGame(model);
            return Json(new { model = step }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Step(ProcessGameView model)
        {
            ProcessGameView step = _gameService.Step(model);
            return Json(new { model = step }, JsonRequestBehavior.AllowGet);
        }
    }
}