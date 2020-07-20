using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Models
{
    public class Reservation
    {
        public Reservation()
        {
           
        }

        public int reservationId { get; set; }
        public DateTime reservationDate { get; set; }
        public DateTime startHour { get; set; }
        public DateTime endHour { get; set; }
        

        public Customer customer { get; set; }
        public Service service { get; set; }
        public Professional professional { get; set; }
        public Status status { get; set; }
        
    }
}
