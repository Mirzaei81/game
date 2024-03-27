using gameapi.repository;
using Grpc.Core;

namespace gameapi.Services.GrpcGameService
{
	public class GrpcGameService : GetGameId.GetGameIdBase
	{
		private readonly IgameRepository _repository;
		private readonly ILogger _logger;
		public GrpcGameService(IgameRepository repository,ILogger<GrpcGameService> logger)
		{
			_repository = repository;
			_logger = logger;
		}

		public override Task<SendGameResponse> GetGamesById(GetByIdRequest request,ServerCallContext context)
		{
			Console.WriteLine(request.UserId);
			var response = new SendGameResponse();
			var games = _repository.GameByUserId(request.UserId);
			_logger.LogInformation($"Game Sendings are {games.Count}");
			foreach(GameModel game in games)
			{
				Console.WriteLine("adding");
				Console.WriteLine(game.Name);
				response.Game.Add(game);
			}
			Console.WriteLine("--> sending games with grpc" + response.Game);
			return Task.FromResult(response);

		}
	}
}
