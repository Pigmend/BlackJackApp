using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.BusinessLogicLayer.Infrastructure;
using BlackJack.ViewModels.Game;

namespace BlackJack.WEB.Controllers
{
    public class GameController : Controller
    {
        IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public ActionResult GameTable()
        {
            GameDataViewModel model = gameService.GetDataForGame();

            return View(model);
        }
    }
}