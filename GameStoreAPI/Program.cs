

using GameStoreAPI.Endpoints;
using GameStoreAPI.Entities;
using GameStoreAPI.Repositories;


//const string GET_GAME_ENDPOINTNAME = "GetGame";

//var games = new List<Game>()
//{
//    new Game()
//    {
//        Id = 1,
//        Genre = "Test Genre",
//        Name = "Test Name",
//        ImageUri = "Test Image",
//        Price = 15,
//        ReleaseDate = DateTime.Now,
//    }
//};

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IGamesRepository, InMemGamesRepository>();   

var app = builder.Build();

app.MapGamesEndpoints();

//var group = app.MapGroup("/games")
//    .WithParameterValidation();

//group.MapGet("/", () => games);

//group.MapGet("/{id}", (int id) =>
//{

//    Game? game = games.Find(w => w.Id == id);

//    if (game is null) return Results.NotFound();

//    return Results.Ok(game);

//}).WithName(GET_GAME_ENDPOINTNAME);

//group.MapPost("/", (Game game) =>
//{

//    game.Id = games.Max(w => w.Id) + 1;

//    games.Add(game);


//    return Results.CreatedAtRoute(GET_GAME_ENDPOINTNAME, new { Id = game.Id }, game);

//});

//group.MapPut("/{id}", (int id, Game updatedGame) =>
//{

//    var existingGame = games.Find(w => w.Id == id);

//    if (existingGame == null) return Results.NotFound();

//    existingGame.Name = updatedGame.Name;
//    existingGame.Genre = updatedGame.Genre;
//    existingGame.Price = updatedGame.Price;
//    existingGame.ReleaseDate = updatedGame.ReleaseDate;
//    existingGame.ImageUri = updatedGame.ImageUri;


//    return Results.NoContent();

//});

//app.MapDelete("/{id}", (int id) =>
//{

//    var game = games.Find(w => w.Id == id);

//    if (game == null) return Results.NotFound();

//    games.Remove(game);

//    return Results.NoContent();

//});

app.Run();
