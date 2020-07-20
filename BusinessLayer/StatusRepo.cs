using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;

namespace HouseCleanersApi.BusinessLayer
{
    public class StatusRepo : RepositoryBase<Status>, IStatusRepo
    {
        public StatusRepo(clearnersDbContext context) : base(context)
        {
        }
    }
}