using GameStoreAPI.Entities;

namespace GameStoreAPI.Repositories
{
    public class InMemGamesRepository : IGamesRepository
    {

        static List<Game> games = new()
        {
            new Game()
            {
                Id = 1,
                Genre = "Hope",
                Name = "Trust God",
                ImageUri = "https://placehold.co/100",
                Price = 0.99M,
                ReleaseDate = DateTime.Now,
            },
            new Game()
            {
                Id = 2,
                Genre = "Hope",
                Name = "Trust Yourself",
                ImageUri = "https://placehold.co/100",
                Price = 1.99M,
                ReleaseDate = DateTime.Now,
            },
        };

        //public async Task<IEnumerable<Game>> GetAllAsync(int pageNumber, int pageSize, string? filter)
        //{
        //    var skipCount = (pageNumber - 1) * pageSize;

        //    return await Task.FromResult(FilterGames(filter).Skip(skipCount).Take(pageSize));
        //}

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await Task.FromResult(games);
        }

        public async Task<Game?> GetAsync(int id)
        {
            return await Task.FromResult(games.Find(game => game.Id == id));
        }

        public async Task CreateAsync(Game game)
        {
            game.Id = games.Max(game => game.Id) + 1;
            games.Add(game);

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Game updatedGame)
        {
            var index = games.FindIndex(game => game.Id == updatedGame.Id);
            games[index] = updatedGame;

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var index = games.FindIndex(game => game.Id == id);
            games.RemoveAt(index);

            await Task.CompletedTask;
        }

        public async Task<int> CountAsync(string? filter)
        {
            return await Task.FromResult(FilterGames(filter).Count());
        }

        private IEnumerable<Game> FilterGames(string? filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                return games;
            }

            return games.Where(game => game.Name.Contains(filter) 
                || game.Genre.Contains(filter));
        }

    }
}
