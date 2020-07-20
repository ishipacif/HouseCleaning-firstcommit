using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;

namespace HouseCleanersApi.BusinessLayer
{
    public class CustomersRepo: RepositoryBase<Customer>, ICustomersRepo
    {
        public CustomersRepo(clearnersDbContext context) : base(context)
        {
        }
    }
}