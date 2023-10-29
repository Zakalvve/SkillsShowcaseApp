using MVCSkillsShowcaseApp.Models.Games;

namespace MVCSkillsShowcaseApp.Services
{
    public interface IBoardGameClient
    {
        Task<BoardGameModel> GetGameByIdAsync(string gameId);
        Task<IEnumerable<BoardGameResultModel>> GetGamesBySearchTermAsync(string searchTerm);
    }
}
