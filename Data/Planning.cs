using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseCleanersApi.Data
{
    public partial class Planning
    {
        public int planingId { get; set; }
        
        public DateTime planingDate { get; set; }
        [Required]
        public DateTime startHour { get; set; }
        [Required]
        public DateTime endHour { get; set; }
        [Required]
        public TimeSpan timeSlot { get; set; }
        [Required]
        public TimeSpan startBreakTime { get; set; }
        [Required]
        public TimeSpan endBreakTime { get; set; }

        public bool saterday { get; set; }
        public bool sunday { get; set; }

        public int? professionalId { get; set; }

        public virtual Professional professionnal { get; set; }
        
    }
}
