using PRACTICK3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PRACTICK3.Service
{
    public interface IBoardgameService
    {
        Task<Boardgame> GetGameAsync(int id);
        Task<Boardgame> AddGamesAsync(Boardgame bordgame);
        Task<IEnumerable<Boardgame>> GetGamesAsync();
        Task DeleteGameAsync(int id);
        Task<Boardgame> UpdategameAsync(Boardgame boardgame);
    }
}