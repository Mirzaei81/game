using gameapi.dtos;
using gameapi.Model;
using gameapi.repository;
using System.Text.Json;
namespace gameapi.EventProcceser
{
    public interface IEventProcceser
    {
        public void ProccesEvent(string massage);
    }
    public class EventProcceser : IEventProcceser
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger _logger;
        public EventProcceser(IServiceScopeFactory scopeFactory,ILogger logger)
        {
            this._scopeFactory = scopeFactory;  
            this._logger= logger;  
        }

        public void ProccesEvent(string massage)
        {
            EventType eventType = DetermineType(massage);
            
            switch(eventType)
            {
                case EventType.GameRateDto:

                default:
                    break;
            }
        }

        private EventType DetermineType(string massage)
        {
            _logger.LogDebug("DetermineMasssage");

            var eventType = JsonSerializer.Deserialize<GenricEvent>(massage);
            switch(eventType!.Event)
            {
                case "GameRated":
                    _logger.LogDebug("Event is Reciving a GameRated");
                    return EventType.GameRateDto;
                default:
                    _logger.LogDebug("EventType Not Found");
                    return EventType.Undermined;
            }

        }

        private async void  addRateGame(string PublishedGameRated)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<gameRepsitory>();

                var GameRated = JsonSerializer.Deserialize<GameRateDto>(PublishedGameRated);

                try
                {
                    UserGameRate gameRate = new(){
                        GameId = GameRated!.GameId,
                        UserId = GameRated.UserId,
                        Rate = GameRated.Rate
                    };
                    await repo.RateGame(gameRate);
                }
                catch(Exception ex)
                {
                    _logger.LogDebug($"Could'nt add GameRated to DataBase{ex}");
                }
            }
        }
    }

    enum EventType
    {
         GameRateDto,
         Undermined
    }
}
