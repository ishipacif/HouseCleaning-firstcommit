namespace HouseCleanersApi.Models
{
    public class InvoiceLineCreateUpdateModel
    {
       
                 public int invoicelineId { get; set; }
                 public int? invoiceId { get; set; }
                 public int? reservationId{ get; set; }
                 public decimal hourCount { get; set; }
                 public decimal hourPrice { get; set; }
                 public decimal pourcentCommission { get; set; }
                 public decimal preCommission { get; set; }
                 public decimal commissionTotal { get; set; }
                 public decimal amount { get; set; }
                 
               
    }
}