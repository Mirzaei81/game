using Microsoft.AspNetCore.Identity;
namespace authapi.Models
{
    public class User:IdentityUser
    {
        public string fullname {get;set;} = string.Empty;
        public string RefreshToken {get;set;} = string.Empty;
        public DateTime RefreshExpiry {get;set;}

    }
}
