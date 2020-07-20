using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;

namespace HouseCleanersApi.BusinessLayer
{
    public class CategoriesRepo : RepositoryBase<Categorie>, ICategoriesRepo
    {
        public CategoriesRepo(clearnersDbContext context) : base(context)
        {
        }
    }
}