using System.Linq;
using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HouseCleanersApi.BusinessLayer
{
    public class ProfessionalServiceRepo: RepositoryBase<ProfessionalService>,IProfessionalServiceRepo
    {
        public ProfessionalServiceRepo(clearnersDbContext context) : base(context)
        {
            
        }
       
    }
}