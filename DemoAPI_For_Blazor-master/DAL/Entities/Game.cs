using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Genre { get; set; }
        public int DateDeSortie { get; set; }
        public int Note { get; set; }
    }
}
