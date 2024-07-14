using GameStoreAPI.Entities;
using GameStoreAPI.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GameStoreAPI.Endpoints;

public static class GamesEndPoints
{
    const string GET_GAME_ENDPOINTNAME = "GetGame";

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
    //
    //
    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {

        var group = routes.MapGroup("/games")
            .WithParameterValidation();


        // Get All.

        /*group.MapGet("/", () => games);*/

        group.MapGet("/", async (IGamesRepository repository) =>
        {
            var test = string.Empty;

            return Results.Ok((await repository.GetAllAsync()));

        });


        // Get Single. 
        group.MapGet("/{id}", async (int id, IGamesRepository repository) =>
        {
            Game? game = await repository.GetAsync(id);

            if (game is null) return Results.NotFound();

            return Results.Ok(game);

        }).WithName(GET_GAME_ENDPOINTNAME);


        // Post Game
        group.MapPost("/", async  (IGamesRepository repository, CreateGameDto gameDto) =>
        {
            /*game.Id = games.Max(w => w.Id) + 1;
            games.Add(game);*/

            var game = new Game()
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate,
                ImageUri = gameDto.ImageUri,
            };

            await repository.CreateAsync(game);

            return Results.CreatedAtRoute(GET_GAME_ENDPOINTNAME, new { Id = game.Id }, game);
        });

        
        // Update
        group.MapPut("/{id}", async (IGamesRepository repository, int id, UpdateGameDto updatedGame) =>
        {

            Game? existingGame = await repository.GetAsync(id);

            if (existingGame == null) return Results.NotFound();

            existingGame.Name = updatedGame.Name;
            existingGame.Genre = updatedGame.Genre;
            existingGame.Price = updatedGame.Price;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;
            existingGame.ImageUri = updatedGame.ImageUri;

            //await repository.UpdateAsync(existingGame);

            /* return Results.NoContent();*/
            return TypedResults.NoContent();
        });

        group.MapDelete("/{id}", async (IGamesRepository repository, int id) =>
        {
            Game? game = await repository.GetAsync(id);

            if (game == null) return Results.NotFound();

            await repository.DeleteAsync(id);

            //games.Remove(game);

            return Results.NoContent();
        });

        return group;
    }
}
