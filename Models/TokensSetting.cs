namespace HouseCleanersApi.Models
{
    public class TokensSetting
    {
        public string key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        
        public string ExpiryInMinutes { get; set; }
        
    }
}