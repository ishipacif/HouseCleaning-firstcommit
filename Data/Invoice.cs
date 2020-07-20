using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Data
{
    public partial class Invoice
    {
        public Invoice()
        {
        }

        public int invoiceId { get; set; }
        public DateTime invoiceDate { get; set; }
        public decimal invoiceAmountTotal { get; set; }
        
        public int? customerId { get; set; }

        public virtual Customer customer { get; set; }
      
        public virtual ICollection<InvoiceLine> invoiceLines { get; set; } = new HashSet<InvoiceLine>();
    }
}
