using System.Collections.Generic;
using HouseCleanersApi.Data;

namespace HouseCleanersApi.Interfaces
{
    public interface IInvoiceLinesRepo : IRepositoryBase<InvoiceLine>
    {
        IEnumerable<InvoiceLine> GetInvoiceLineByCustomer(int customerid);

    }
}