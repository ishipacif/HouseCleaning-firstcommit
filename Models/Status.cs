using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Models
{
    public class Status
    {
        public Status()
        {
        
        }

        public int statusId { get; set; }
        public string statusName { get; set; }
        public string statusDescription { get; set; }

       
    }
}
