using PRACTICK3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using PRACTICK3.Repositories;

namespace PRACTICK3.Service
{
    public class BoardgameService : IBoardgameService
    {
        private readonly IBoardgameRepository _boardgameRepositiry;
        
        public BoardgameService(IBoardgameRepository boardgameRepositiry)
        {
            _boardgameRepositiry = boardgameRepositiry;
        }

        public async Task<Boardgame> AddGamesAsync(Boardgame bordgame)
        {
            return await _boardgameRepositiry.AddGamesAsync(bordgame);
        }

        public async Task DeleteGameAsync(int id)
        {
            await _boardgameRepositiry.DeleteGameAsync(id);
        }

        public async Task<Boardgame> GetGameAsync(int id)
        {
            return await _boardgameRepositiry.GetGameAsync(id);
        }

        public async Task<IEnumerable<Boardgame>> GetGamesAsync()
        {
            return await _boardgameRepositiry.GetGamesAsync();
        }

        public async  Task<Boardgame> UpdategameAsync(Boardgame boardgame)
        {
            return await _boardgameRepositiry.UpdategameAsync(boardgame);
        }
    }
}