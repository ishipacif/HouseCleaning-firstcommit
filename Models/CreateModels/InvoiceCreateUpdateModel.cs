using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Models
{
    public class InvoiceCreateUpdateModel
    {
        public InvoiceCreateUpdateModel()
                 {
                     invoiceLines=new List<InvoiceCreateUpdateModel>();
                 }
         
                 public int invoiceId { get; set; }
                 public DateTime invoiceDate { get; set; }
                 public decimal invoiceAmountTotal { get; set; }
               
                 public  int customerId { get; set; }
                 public  List<InvoiceCreateUpdateModel> invoiceLines { get; set; } 
         
     }
 }