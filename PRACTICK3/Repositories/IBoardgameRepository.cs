using PRACTICK3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICK3.Service
{
   public  interface IBoardgameRepository : IDisposable
    {
        Task<Boardgame> GetGameAsync(int id);
        Task<Boardgame> AddGamesAsync(Boardgame bordgame);
        Task<IEnumerable<Boardgame>> GetGamesAsync();
        Task DeleteGameAsync(int id);
        Task<Boardgame> UpdategameAsync(Boardgame boardgame);
    }
}
