using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseCleanersApi.Data
{
    public partial class Service
    {
        public Service()
        {
            reservations = new HashSet<Reservation>();
            professionals = new HashSet<ProfessionalService>();
            
        }

        public int serviceId { get; set; }
        [Required]
        public string serviceName { get; set; }
        [Required]
        public string serviceDescription { get; set; }
        
        [Required]
        public int? categoryId { get; set; }
        public decimal price { get; set; } 

        public virtual Categorie category { get; set; }
        public virtual ICollection<Reservation> reservations { get; set; }
        public virtual IEnumerable<ProfessionalService> professionals { get; set; }
    }
}
