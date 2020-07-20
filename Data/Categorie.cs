using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseCleanersApi.Data
{
    public partial class Categorie
    {
        public Categorie()
        {
            services = new HashSet<Service>();
        }

        public int categoryId { get; set; }
        [Required]
        public string categoryName { get; set; }
        [Required]
        public string categoryDescription { get; set; }

        public virtual ICollection<Service> services { get; set; }
    }
}
