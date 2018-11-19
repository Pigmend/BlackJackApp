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
    public class HistoryController : Controller
    {
        private IHistoryService _historyService { get; set; }

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        public ActionResult ShowHistory(long UserId)
        {
            ShowHistoryUserView item = _historyService.ShowHistory(UserId);
            return View(item);
        }

        public ActionResult ShowGameHistory(long GameId)
        {
            ShowGameHistoryUserView item = _historyService.ShowGameHistory(GameId);
            return View(item);
        }

        public ActionResult ShowStep(long StepId)
        {
            ShowStepHistoryView item = _historyService.ShowStep(StepId);
            return View(item);
        }
    }
}