using System.ComponentModel.DataAnnotations;

namespace HouseCleanersApi.Models
{
    public class ServiceCreateUpdateModes
    {
        public ServiceCreateUpdateModes()
        {
        
        }

        public int serviceId { get; set; }
        [Required]
        public string serviceName { get; set; }
        [Required]
        public string serviceDescription { get; set; }
        
        [Required]
        public int? categoryId { get; set; }
        public decimal price { get; set; } 


    }
}