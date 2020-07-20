using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseCleanersApi.Data
{
    public partial class Reservation
    {
        public Reservation()
        {
            invoiceLines = new HashSet<InvoiceLine>();
        }

        public int reservationId { get; set; }
        [Required]
        public DateTime reservationDate { get; set; }
        [Required]
        public DateTime startHour { get; set; }
        [Required]
        public DateTime endHour { get; set; }
        public int? professionalId { get; set; }
        public int? customerId { get; set; }
        public int? ServiceId { get; set; }
        public int? statusId { get; set; }

        public virtual Customer customer { get; set; }
        public virtual Service Service { get; set; }
        public virtual Professional professional { get; set; }
        public virtual Status status { get; set; }
        public virtual ICollection<InvoiceLine> invoiceLines { get; set; }
    }
}
