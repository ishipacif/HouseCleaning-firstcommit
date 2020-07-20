using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Models
{
    public class Customer
    {
        public Customer()
        {
            invoices = new List<Invoice>();;
            reservations = new List<Reservation>();
        }

        public int customerId { get; set; }
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
        public string password { get; set; }
         public User user { get; set; }
        public string passwordComfirm { get; set; }
        public  List<Invoice> invoices { get; set; }
        public  List<Reservation> reservations { get; set; }
    }
}
