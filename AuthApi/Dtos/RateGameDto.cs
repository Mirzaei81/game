namespace authapi.dto
{
    public class RateGameDto
    {
        public string gameId  {get;set;} = string.Empty;
        public int UserId  {get;set;}
        public int Rate  {get;set;}
        public GenricEvent Event {get;set;} = new ();
    }
}
