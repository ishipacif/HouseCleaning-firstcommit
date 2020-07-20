using System.Linq;
using HouseCleanersApi.Data;

namespace HouseCleanersApi.Interfaces
{
    public interface IProfessionalRepo : IRepositoryBase<Professional>
    {
        IQueryable<Professional> ProfessionalByService(int serviceId);
        IQueryable<Professional> GetAllProfessionnal();

    }
    
}