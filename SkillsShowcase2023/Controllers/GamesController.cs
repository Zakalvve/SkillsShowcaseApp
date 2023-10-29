using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MVCSkillsShowcaseApp.Models.Games;
using MVCSkillsShowcaseApp.Services;

namespace MVCSkillsShowcaseApp.Controllers
{
    public class GamesController : Controller
    {
        private readonly IBoardGameClient _boardGameClient;

        public GamesController(IBoardGameClient boardGameClient)
        {
            _boardGameClient = boardGameClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchTerm)
        {
            if (searchTerm.IsNullOrEmpty()) return View(new List<BoardGameResultModel>());

            var results = await _boardGameClient.GetGamesBySearchTermAsync(searchTerm);

            return View(results);
        }


        [HttpPost]
        public IActionResult SearchGames([FromForm]string searchTerm)
        {
            return RedirectToAction("Index", new { searchTerm });
        }

        [HttpGet]
        public async Task<IActionResult> ViewGame(string gameId)
        {
            if (gameId.IsNullOrEmpty()) RedirectToAction("Index");

            var result = await _boardGameClient.GetGameByIdAsync(gameId);

            return View(result);
        }
    }
}
