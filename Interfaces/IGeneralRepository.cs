namespace HouseCleanersApi.Interfaces
{
    public interface IGeneralRepository
    {
        IProfessionalRepo professional { get; }
        ICustomersRepo Customers { get; }
        ICategoriesRepo categorie { get; }
        IServicesRepo service { get; }
        IInvoiceRepo invoice { get; }
        IInvoiceLinesRepo invoicelines { get; }
        IPlanningsRepo planning { get; }
        IReservationsRepo reservation { get; }
        IStatusRepo status { get; }
        IProfessionalServiceRepo ProfessionalServices{ get; }
        IDisponibilityRepo Disponibility { get; }
    }
    
}