using PRACTICK3.Models;
using PRACTICK3.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICK3.Common
{
    public class  BoardgameContext: DbContext
    {
        public BoardgameContext() : base("DefaultConnection")
        {
           
        }
        public   DbSet<Boardgame> Boardgames { get; set; }
    }
}
