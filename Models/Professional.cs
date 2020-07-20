using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Models
{
    public class Professional
    {
        public Professional()
        {
            invoices = new List<Invoice>();
            plannings = new List<Planning>();
            reservations = new List<Reservation>();
        }

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
         public string userId { get; set; }
         public bool active { get; set; }

        public string password { get; set; }

        public string passwordComfirm { get; set; }
         public User user { get; set; }
        public List<Invoice> invoices { get; set; }
        public  List<Planning> plannings { get; set; }
        public List<Reservation> reservations { get; set; }
    }
}
