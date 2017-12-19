using PRACTICK3.Common;
using PRACTICK3.Models;
using PRACTICK3.Repositories;
using PRACTICK3.Service;
using PRACTICK3.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PRACTICK3.Controllers
{
    public class BoardGameController : Controller
    {

        IBoardgameRepository _boardService;

        public BoardGameController()
        {
            _boardService = new BoardgameRepository();
        }
        public async  Task<ActionResult> Index()
        {
            var boardgame = await  _boardService.GetGamesAsync();
            return View(boardgame);
        }
        public ActionResult AddGame()
        {
            var boardgameViewModel = new BoardgameViewModel
            {
                Title = "Add new Game",
                AddButtonTitle = "Add",
                RedirectUrl = Url.Action("Index", "BoardGame")

            };
            return View(boardgameViewModel);
        }
        public async Task<ActionResult> DetailsOfGame(int id)
        {
            var boardgame = await _boardService.GetGameAsync(id);

            return View(new BoardgameViewModel { Id = boardgame.ProductId, Description = boardgame.Description, ProductName = boardgame.ProductName, Coast=boardgame.Coast , Count = boardgame.Count });
        }

        [HttpPost]
        public async Task<ActionResult> SaveGame(BoardgameViewModel boardgameViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(boardgameViewModel);
            }

            var boardgame = await _boardService.GetGameAsync(boardgameViewModel.Id);
            if (boardgame != null)
            {
                boardgame.ProductName = boardgameViewModel.Name;
                boardgame.Description = boardgameViewModel.Description;
                boardgame.ProductName = boardgameViewModel.ProductName;
                boardgame.Coast = boardgameViewModel.Coast;
                boardgame.Count = boardgameViewModel.Count;
                await _boardService.UpdategameAsync(boardgame);
            }

            return RedirectToLocal(redirectUrl);
        }

        public async Task<ActionResult> EditGame(int id)
        {
            var boardgame = await _boardService.GetGameAsync(id);

            var studentViewModel = new BoardgameViewModel
            {
                Title = "Edit Game",
                AddButtonTitle = "Save",
                RedirectUrl = Url.Action("Index", "BoardGame"),
                Name = boardgame.ProductName,
                Id = boardgame.ProductId
            };

            return View(studentViewModel);
        }

        public async Task<ActionResult> DeleteStudent(int id)
        {
            await _boardService.DeleteGameAsync(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> AddNewGame(BoardgameViewModel boardViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(boardViewModel);
            }

            var boardgame = new Boardgame
            {
                ProductName = boardViewModel.Name,
                Coast = boardViewModel.Coast,
                Rang = boardViewModel.Rang,
                Description = boardViewModel.Description,
                Count = boardViewModel.Count
                
            };

            await _boardService.AddGamesAsync(boardgame);

            return RedirectToLocal(redirectUrl);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "BoardGame");
        }
    }
}