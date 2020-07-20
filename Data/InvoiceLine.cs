using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Data
{
    public partial class InvoiceLine
    {
        public int invoicelineId { get; set; }
        public int? invoiceId { get; set; }
        public int? reservationId { get; set; }
        public decimal hourCount { get; set; }
        public decimal hourPrice { get; set; }
        public decimal amount { get; set; }

        public virtual Invoice invoice { get; set; }
        public virtual Reservation reservation{ get; set; }
    }
}
