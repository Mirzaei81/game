using System.ComponentModel.DataAnnotations;
namespace authapi.dto
{
    public class login
    {
        [Required]
        public string Username {get;set;} = string.Empty;
        [Required]
        public string  password {get;set;} = string.Empty;
    }
}


