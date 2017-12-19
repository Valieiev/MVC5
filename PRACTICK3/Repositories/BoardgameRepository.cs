using PRACTICK3.Models;
using PRACTICK3.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using PRACTICK3.Common;
using System.Data.Entity;

namespace PRACTICK3.Repositories
{
    public class BoardgameRepository : IBoardgameRepository
    {
    
        public BoardgameRepository() { }
      

        public async Task<Boardgame> GetGameAsync(int id)
        {
            Boardgame result = null;
            using (var boardgameContext = new BoardgameContext())
            {
                result = await boardgameContext.Boardgames.FirstOrDefaultAsync(f => f.ProductId == id);
            }
            return result;
        }

        public async Task<Boardgame> AddGamesAsync(Boardgame bordgame)
        {
            Boardgame result = null;
            using (var boardgameContext = new BoardgameContext())
            {
                result = boardgameContext.Boardgames.Add(bordgame);
                await boardgameContext.SaveChangesAsync();
            }
            return result;
        }

       public async  Task<IEnumerable<Boardgame>> GetGamesAsync()
        {
            var result = new List<Boardgame>();
            using (var boardgameContext = new BoardgameContext())
            {
                result = await boardgameContext.Boardgames.ToListAsync();
                 
            }
            return result;
        }

        public async Task DeleteGameAsync(int id)
        {
            using (var boardgameContext = new BoardgameContext())
            {
                var boardgame = await boardgameContext.Boardgames.FirstOrDefaultAsync(f => f.ProductId == id);
                boardgameContext.Entry(boardgame).State = EntityState.Deleted;
                await boardgameContext.SaveChangesAsync();
            }
        }

        public async Task<Boardgame> UpdategameAsync(Boardgame boardgame)
        {
            using (var boardgameContext = new BoardgameContext())
            {
                boardgameContext.Entry(boardgame).State = EntityState.Modified;
                await boardgameContext.SaveChangesAsync();
            }
            return boardgame;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    using (var boardgameContext = new BoardgameContext())
                    {
                        boardgameContext.Dispose();
                    }
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}