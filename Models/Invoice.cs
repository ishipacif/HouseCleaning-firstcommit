using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Models
{
    public class Invoice
    {
        public Invoice()
        {
            invoiceLines=new List<InvoiceLine>();
        }

        public int invoiceId { get; set; }
        public DateTime invoiceDate { get; set; }
        public decimal invoiceAmountTotal { get; set; }
        public int customerId  { get; set; }
        public  Customer customer { get; set; }
        
        public  List<InvoiceLine> invoiceLines { get; set; } 
    }
}
