using System.Linq;
using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HouseCleanersApi.BusinessLayer
{
    public class ServicesRep : RepositoryBase<Service>, IServicesRepo
    {
        public ServicesRep(clearnersDbContext context) : base(context)
        {
            
        }
        public IQueryable<Service> ServicesByProfessionnal(int professionalId)
        {
          
                       return _context.Services.Join(
                           _context.ProfessionalServices.Where(x => x.serviceId == professionalId),
                           d => d.serviceId,
                           f => f.serviceId,
                           (d, f) => d);
           
                       //  return _context.ProfessionalServices.Where(p => p.serviceId == serviceId).Include(e => e.professional);

        }

        public IQueryable<Service> GetServices()
        {
            return _context.Services.Include(x => x.category);
        }

        public Service GetService(int id)
        {
            return _context.Services
                .Include(x => x.category)
                .FirstOrDefault(x => x.serviceId == id);

        }

        public IQueryable<Service> GetServiceByCategory(int id)
        {
            return _context.Services.Include(x => x.category).Where(x => x.categoryId == id);
        }
       
    }
}