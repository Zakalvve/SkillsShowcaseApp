using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MVCSkillsShowcaseApp.Models.Games;
using MVCSkillsShowcaseApp.Services;

namespace MVCSkillsShowcaseApp.Controllers
{
    public class GamesController : Controller
    {
        private readonly ILogger<GamesController> _logger;
        private readonly IBoardGameClient _boardGameClient;

        public GamesController(ILogger<GamesController> logger, IBoardGameClient boardGameClient)
        {
            _logger = logger;
            _boardGameClient = boardGameClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchTerm)
        {
            if (searchTerm.IsNullOrEmpty()) return View(new List<BoardGameResultModel>());

            try
            {
                var results = await _boardGameClient.SearchGamesAsync(searchTerm);
                return View(results);
            } 
            catch(ArgumentException e)
            {
                _logger.LogWarning(e.Message);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }
            return View(new List<BoardGameResultModel>());
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

            try
            {
                var result = await _boardGameClient.GetGameByIdAsync(gameId);

                return View(result);
            } 
            catch(ArgumentException e)
            {
                _logger.LogWarning(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return RedirectToAction("Index");
        }
    }
}