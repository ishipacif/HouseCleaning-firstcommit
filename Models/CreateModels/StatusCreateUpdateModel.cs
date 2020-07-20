namespace HouseCleanersApi.Models
{
    public class StatusCreateUpdateModel
    {
        public StatusCreateUpdateModel()
        {
        
        }

        public int statusId { get; set; }
        public string statusName { get; set; }
        public string statusDescription { get; set; }
    }
}