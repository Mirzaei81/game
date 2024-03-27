namespace gameapi.dtos
{
    public class GameRateDto
    {
        public string UserId{get;set;} = string.Empty;
        public int Rate{get;set;}
        public int GameId{get;set;}
        public string Event{get;set;} = string.Empty;
    }
}
