using System;
using System.ComponentModel.DataAnnotations;

namespace PRACTICK3.Models
{
    public class Boardgame
    {

        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Coast { get; set; }
        public int Rang { get; set; }
        public int Count { get; set; }

        
    }
    
}