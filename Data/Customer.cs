using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseCleanersApi.Data
{
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
            Reservations = new HashSet<Reservation>();
        }

        public int customerId { get; set; }
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

        
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
