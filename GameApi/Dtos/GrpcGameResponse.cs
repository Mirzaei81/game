namespace gameapi.dtos
{
    public class GrpcGameDto
    {
	public int Id  {get;set;}
	public string Name {get;set;} = string.Empty;
	public string ImageUrl {get;set;} = string.Empty;
	public int Fullrating {get;set;} 
	public int rating {get;set;} 
	public int ratingcount {get;set;}
    }
}

