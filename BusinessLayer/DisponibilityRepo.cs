using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;

namespace HouseCleanersApi.BusinessLayer
{
    public class DisponibilityRepo: RepositoryBase<Disponibility>, IDisponibilityRepo
    {
        public DisponibilityRepo(clearnersDbContext context) : base(context)
        {
        }
    }
}