using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Infrastructure;
using BlackJack.ViewModels.Response;
using BlackJack.ViewModels.Request;

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
            ResponseGameProcessViewModel newGameView = _gameService.GetGameData(id);
            return View(newGameView);
        }

        [HttpPost]
        public ActionResult SaveChanges(RequestSaveChangesGameViewModel requestData)
        {
            bool isSaved = _gameService.SaveChanges(requestData);
            return Json(new { isSaved, JsonRequestBehavior.AllowGet });
        }

        [HttpGet]
        public ActionResult GetCard()
        {
            RequestGetCardGameViewModel item = _gameService.GetCard();
            return Json(new { card = item }, JsonRequestBehavior.AllowGet);
        }
    }
}