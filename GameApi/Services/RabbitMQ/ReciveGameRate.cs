using RabbitMQ.Client;
namespace gameapi.servies.rabbitmq
{
	public class GetGameRate
	{
		private readonly IConfiguration _config;
		private readonly ILogger _logger;
		private readonly IConnection _connection;
		private readonly IModel _channel;
		public GetGameRate(ILogger logger,IConfiguration config)
		{
			this._config= config;
			this._logger= logger;
			var factory = new ConnectionFactory() {HostName=_config["RabbitMQ"]};
			_connection = factory.CreateConnection();
			_channel = _connection.CreateModel();
		}
		public void ReciveGame()
		{
		}
	}
}
