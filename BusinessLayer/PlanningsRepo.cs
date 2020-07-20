using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;

namespace HouseCleanersApi.BusinessLayer
{
    public class PlanningsRepo : RepositoryBase<Planning>, IPlanningsRepo
    {
        public PlanningsRepo(clearnersDbContext context) : base(context)
        {
        }
    }
}