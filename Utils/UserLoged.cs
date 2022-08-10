namespace back.Utils
{
    public class UserLoged
    {
        public string Username {get;set;}
        public string Email {get;set;}
        public DateTime data {get;set;} = DateTime.Now;
        public string token {get; set;}
    }
    
}