using System.Linq;
using HouseCleanersApi.Data;

namespace HouseCleanersApi.Interfaces
{
    public interface IServicesRepo: IRepositoryBase<Service>
    {
        IQueryable<Service> ServicesByProfessionnal(int professionalId);
        IQueryable<Service> GetServices();
        Service GetService(int id);
        IQueryable<Service> GetServiceByCategory(int id);

    }  

}