using System.Runtime.CompilerServices;

namespace GameStoreAPI.Entities;

public static class EntityExtensions
{
    public static GameDto AsDTO(this GameDto game)
    {
        return new GameDto(
            game.Id,
            game.Name,
            game.Genre,
            game.Price,
            game.ReleaseDate,
            game.ImageUri
        );

    }
}
