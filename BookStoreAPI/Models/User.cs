namespace BookStoreAPI.Models
{
    public abstract class User :BaseEntity
    {
        public string UserName { get; set; } 
        public string Password { get; set; }
        public string Role { get; set; }
        public string RefreshToken { get; set; }
        public bool IsBlocked { get; }



    }
}
