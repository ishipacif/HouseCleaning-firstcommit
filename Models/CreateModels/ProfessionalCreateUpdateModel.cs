namespace HouseCleanersApi.Models
{
    public class ProfessionalCreateUpdateModel
    {
            public int professionalId { get; set; }
            public string firstName { get; set; }
             public string lastName { get; set; }
             public string email { get; set; }
             public string phoneNumber { get; set; }
             public string streetName { get; set; }
             public string plotNumber { get; set; }
             public string city { get; set; }
             public int postCode { get; set; }
             public string geoCoords { get; set; }
             public string picture { get; set; }
             public bool active { get; set; }
     
             public string password { get; set; }
     
             public string passwordComfirm { get; set; }
             
        
    }
}