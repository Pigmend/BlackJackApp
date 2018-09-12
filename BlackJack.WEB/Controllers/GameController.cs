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
    public class GameController : Controller
    {
        IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }
        // GET: Game
        public ActionResult GameTable()
        {
            return View(gameService.GetDataForGame());
        }
    }
}