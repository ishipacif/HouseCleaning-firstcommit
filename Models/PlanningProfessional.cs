using System;

namespace HouseCleanersApi.Models
{
    public class PlanningProfessional
    {
        public int  professionalId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool saturday { get; set; }
        public bool sunday { get; set; }
        public TimeSpan startHour { get; set; }
        public TimeSpan endHour { get; set; }

    }
}