using RabbitMQ.Client;
using authapi.dto;
using System.Text.Json;
using System.Text;
namespace authapi.services.rabbitmq
{
	public class publisher 
	{
		private readonly IConfiguration _configuration;
		private readonly  IConnection _connection;
		private readonly  IModel _channel;
		private readonly ILogger _logger;
		public publisher(IConfiguration configuration,ILogger logger)
		{
			this._configuration = configuration;
			this._logger = logger;
			var factory = new ConnectionFactory() { HostName = "localhost" };
			_connection = factory.CreateConnection();
			_channel = _connection.CreateModel();
			_channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
			_connection.ConnectionShutdown += RabbitMQ_ConnetctionShutdown;
		}


		public void publishRatedGame(RateGameDto data)
		{
			var massage = JsonSerializer.Serialize(data);
			if(_connection.IsOpen)
			{
				_logger.LogDebug("RabbitMQ is Sending a Massage");
				sendmassage(massage);

			}
				
		}

		public void sendmassage(string massage)
		{
			var body = Encoding.UTF8.GetBytes(massage);

			_channel.BasicPublish(exchange: "trigger",
					routingKey: "",
					basicProperties: null,
					body:body);
			
		}

		public void despoie()
		{
			if(_channel.IsOpen)
			{
				_channel.Close();
				_connection.Close();
			}
		}

		public void RabbitMQ_ConnetctionShutdown(object? sernder,ShutdownEventArgs args)
		{
			Console.WriteLine("RabbitMQ is shutting down");
		}
	}
}
		
