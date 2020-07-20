using System.Collections.Generic;
using System.Linq;
using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HouseCleanersApi.BusinessLayer
{
    public class InvoiceLinesRepo : RepositoryBase<InvoiceLine>, IInvoiceLinesRepo
    {
        public InvoiceLinesRepo(clearnersDbContext context) : base(context)
        {
        }

     

        public IEnumerable<InvoiceLine> GetInvoiceLineByCustomer(int customerid)
        {
            return _context.InvoiceLines.Include(x => x.reservation)
                .Where(res => res.reservation.customerId == customerid);
        }
    }
}