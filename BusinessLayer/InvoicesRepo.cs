using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;

namespace HouseCleanersApi.BusinessLayer
{
    public class InvoicesRepo: RepositoryBase<Invoice>, IInvoiceRepo

    {
        public InvoicesRepo(clearnersDbContext context) : base(context)
        {
            
        }

        public int CreateInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
            return invoice.invoiceId;
        }
    }
}