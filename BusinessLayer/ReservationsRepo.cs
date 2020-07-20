using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;

namespace HouseCleanersApi.BusinessLayer
{
    public class ReservationsRepo : RepositoryBase<Reservation>, IReservationsRepo
    {
        public ReservationsRepo(clearnersDbContext context) : base(context)
        {
        }
    }
}