using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Infrastructure;
using BlackJack.ViewModels.Request;

namespace BlackJack.WEB.Controllers
{
    public class HistoryController : Controller
    {
        private IHistoryService _historyService { get; set; }

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        public ActionResult ShowHistory(long UserId)
        {
            ShowHistoryUserViewModel item = _historyService.ShowHistory(UserId);
            return View(item);
        }

        public ActionResult ShowGameHistory(long GameId)
        {
            ShowGameHistoryUserViewModel item = _historyService.ShowGameHistory(GameId);
            return View(item);
        }

        public ActionResult ShowStep(long StepId)
        {
            ShowStepHistoryViewModel item = _historyService.ShowStep(StepId);
            return View(item);
        }
    }
}