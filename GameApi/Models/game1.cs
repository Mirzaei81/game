using System.ComponentModel.DataAnnotations;
namespace gameapi.Model
{
    public class UserGameRate
    {
        [Key]
        public int Id{get;set;}
        public string UserId{get;set;} = string.Empty;
        public int GameId{get;set;}
        [MaxLength(100)]
        public int Rate{get;set;}
    }
}
