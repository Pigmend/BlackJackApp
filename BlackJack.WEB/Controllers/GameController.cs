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
            GameProcessViewModel newGameView = _gameService.GetGameData(id);
            return View(newGameView);
        }

        [HttpPost]
        public ActionResult SaveChanges(SaveChangesGameViewModel requestData)
        {
            bool isSaved = _gameService.SaveChanges(requestData);
            if (isSaved)
            {
                string messageSuccess = "SUCCESS";
                return Json(new { Message = messageSuccess, JsonRequestBehavior.AllowGet });
            }
            if (!isSaved)
            {
                string messageError = "ERROR";
                return Json(new { Message = messageError, JsonRequestBehavior.AllowGet });
            }

            string messageDefault = "IGNORED";
            return Json(new { Message = messageDefault, JsonRequestBehavior.AllowGet });
        }

        public ActionResult ContinueGame(int gameID)
        {
            // ... TO DO!!!
            return View();
        }
    }
}