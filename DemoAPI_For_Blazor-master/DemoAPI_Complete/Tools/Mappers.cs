using DAL.Entities;
using DemoAPI_Complete.DTO;

namespace DemoAPI_Complete.Tools
{
    public static class Mappers
    {
        public static Game ToDal(this GameDTO g)
        {
            return new Game
            {
                Titre = g.Titre,
                Genre = g.Genre,
                DateDeSortie = g.DateDeSortie,
                Note = g.Note
            };
        }
    }
}
