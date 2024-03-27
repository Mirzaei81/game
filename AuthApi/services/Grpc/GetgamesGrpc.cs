using gameapi;
using Grpc.Net.Client;
namespace authapi.services.grpc
{
	public interface IGameDataClient
	{
		public Task<IEnumerable<GameModel>> GetGamesById(Guid id);
	};

	public class GameDataClient:IGameDataClient
	{
		private readonly IConfiguration _configuration;
		public GameDataClient(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task<IEnumerable<GameModel>> GetGamesById(Guid id)
		{
			var channel = GrpcChannel.ForAddress(_configuration["Grpc"]);
			var client  = new GetGameId.GetGameIdClient(channel);
			var request = new GetByIdRequest(){UserId = id.ToString()};

			try
			{
				var reply = await client.GetGamesByIdAsync(request);
				return reply.Game;

			}
			catch(Exception ex)
			{
				Console.WriteLine(ex);
				return null;
			}
		}
	}
}

