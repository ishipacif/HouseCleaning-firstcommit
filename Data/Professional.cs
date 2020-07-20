using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseCleanersApi.Data
{
    public partial class Professional
    {
        public Professional()
        {
            invoices = new HashSet<Invoice>();
            plannings = new HashSet<Planning>();
            reservations = new HashSet<Reservation>();
            services = new List<Service>();
            disponibilities = new List<Disponibility>();
            
        }

        public int professionalId { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        [Required]
        public string streetName { get; set; }
        [Required]
        public string plotNumber { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public int postCode { get; set; }
        public string geoCoords { get; set; }
        public string picture { get; set; }
        public bool active { get; set; }
        public User user { get; set; }
        public string userId { get; set; }
        
        [NotMapped]
        public string password { get; set; }
        [NotMapped]
        
        public string passwordComfirm { get; set; }
        

        public virtual ICollection<Invoice> invoices { get; set; }
        public virtual ICollection<Planning> plannings { get; set; }
        public virtual ICollection<Disponibility> disponibilities { get; set; }
        public virtual ICollection<Reservation> reservations { get; set; }
        public virtual IEnumerable<Service> services { get; set; }
    }
}
