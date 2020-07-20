using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseCleanersApi.Data
{
    public partial class Status
    {
        public Status()
        {
            reservations = new HashSet<Reservation>();
        }

        public int statusId { get; set; }
        [Required]
        public string statusName { get; set; }
        [Required]
        public string statusDescription { get; set; }

        public virtual ICollection<Reservation> reservations { get; set; }
    }
}
