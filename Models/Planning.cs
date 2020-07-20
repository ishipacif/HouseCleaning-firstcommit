using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Models
{
    public class Planning
    {
        public int planingId { get; set; }
        public DateTime planingDate { get; set; }
        public DateTime startHour { get; set; }
        public DateTime endHour { get; set; }
        public TimeSpan timeSlot { get; set; }
        public TimeSpan startBreakTime { get; set; }
        public TimeSpan endBreakTime { get; set; }
        public int? professionalId { get; set; }
        public bool saterday { get; set; }
        public bool sunday { get; set; }

        public virtual Professional professional { get; set; }
    }
}
