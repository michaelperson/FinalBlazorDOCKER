using DAL.Entities;

namespace DAL.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAll();
        Task<Game> GetById(int Id);
        Task CreateGame(Game g);
    }
}