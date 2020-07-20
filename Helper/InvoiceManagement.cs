using HouseCleanersApi.Data;

namespace HouseCleanersApi.Helper
{
    public static class InvoiceManagement
    {
        public static InvoiceLine GetInvoiceLine(Reservation res)
        {
            InvoiceLine invl = new InvoiceLine();
            invl.reservationId = res.reservationId;
            invl.hourCount = (res.endHour - res.startHour).Hours;
            invl.hourPrice = res.Service.price;
            invl.amount = invl.hourCount * invl.hourPrice;
            return invl;
            
        }
    }
}