using HouseCleanersApi.Data;

namespace HouseCleanersApi.Interfaces
{
    public interface IInvoiceRepo : IRepositoryBase<Invoice>
    {
        int CreateInvoice(Invoice invoice);
    }
}