using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace HouseCleanersApi.Data
{
    public class Disponibility
    {
        [Key]
        public int id { get; set; }
        
        
        [Required]
        public DateTime startHour { get; set; }
        [Required]
        public DateTime EndHour { get; set; }
        [Required]
        public int professionalId { get; set; }
        public Professional professional { get; set; }
        public bool reserved { get; set; }
    }
}