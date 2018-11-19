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

        [HttpPost]
        public ActionResult SaveChanges(SaveChangesGameView requestData)
        {
            bool isSaved = _gameService.SaveChanges(requestData);
            return Json(new { isSaved, JsonRequestBehavior.AllowGet });
        }

        [HttpGet]
        public ActionResult GetCard()
        {
            GetCardGameView item = _gameService.GetCard();
            return Json(new { card = item }, JsonRequestBehavior.AllowGet);
        }
    }
}