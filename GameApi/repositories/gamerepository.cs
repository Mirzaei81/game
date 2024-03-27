using gameapi.GameContext;
using gameapi.Model;

namespace gameapi.repository
{
    public interface IgameRepository
    {
        public Task<Game> getGame(int id);
        public Task RateGame(UserGameRate gameRate);
        public List<Game> GetGames();
        public List<GameModel> GameByUserId(string id);
    }


    public class gameRepsitory:IgameRepository
    {
        private readonly gamecontext _context;
        private readonly ILogger _logger;

        public gameRepsitory(gamecontext context,ILogger<IgameRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Game> GetGames()
        {
            return (_context.Games!.ToList()) ?? throw new NullReferenceException("noGames");
        }

        public async Task<Game> getGame(int id)
        {
            return (await _context.Games!.FindAsync(id)) ?? throw new NullReferenceException(nameof(id));
        }

        public async Task RateGame(UserGameRate gameRated)
        {
            Game game = (await _context.Games!.FindAsync(gameRated.GameId)) ?? throw new NullReferenceException(nameof(gameRated.GameId)+"is not Found");
            game.Rating +=gameRated.Rate;
            game.RatingsCount +=1;
            if(_context.UserRate.Any(U => (U.UserId == gameRated.UserId) && (U.GameId == gameRated.GameId)))
            {
                throw new InvalidOperationException();
            }
            await _context.UserRate!.AddAsync(gameRated);
            await _context.SaveChangesAsync();
        }

        public List<GameModel> GameByUserId(string id)
        {
            var game =  _context.Games
                        .Join(_context.UserRate.Where(Users => Users.UserId == id),
                        games => games.Id,
                        Users => Users.GameId,
                        (games,Users) =>
                        new GameModel
                            {
                                Id = games.Id,
                                Name = games.Name,
                                ImageUrl = games.BackgroundImage,
                                Fullrating = games.RatingsCount,
                                Rating = (int) games.Rating,
                                Ratingcount = Users.Rate,
                            }).ToList();

            return game;

        }
    }
}
