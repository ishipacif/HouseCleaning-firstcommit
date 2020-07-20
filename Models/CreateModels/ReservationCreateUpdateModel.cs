using System;

namespace HouseCleanersApi.Models
{
    public class ReservationCreateUpdateModel
    {
            public int reservationId { get; set; }
             public DateTime reservationDate { get; set; }
             public DateTime startHour { get; set; }
             public DateTime endHour { get; set; }
             
            public int professionalId { get; set; }
             public int customerId { get; set; }
             public int ServiceId { get; set; }
             public int statusId { get; set; }
    }
}