using GameStoreAPI.Entities;

namespace GameStoreAPI.Repositories;

public interface IGamesRepository
{
    Task CreateAsync(Game game);
    Task DeleteAsync(int id);
    Task<Game?> GetAsync(int id);
    //Task<IEnumerable<Game>> GetAllAsync(int pageNumber);
    Task<IEnumerable<Game>> GetAllAsync();
    Task UpdateAsync(Game updatedGame);
    Task<int> CountAsync(string? filter);

}
