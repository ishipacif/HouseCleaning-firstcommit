using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;

namespace HouseCleanersApi.BusinessLayer
{
    
    public class GeneralRepository : IGeneralRepository
    {
        private readonly clearnersDbContext _context;
        
        private IProfessionalRepo _professional;
        private ICustomersRepo _customer;
        private ICategoriesRepo _categorie;
        private IServicesRepo _service;
        private IInvoiceRepo _invoice;
        private IInvoiceLinesRepo _invoicelines;
        private IPlanningsRepo _planning;
        private IReservationsRepo _reservation;
        private IStatusRepo _status;
        private IProfessionalServiceRepo _professionalServices;
        private IDisponibilityRepo _disponibility;

        public GeneralRepository(clearnersDbContext context)
        {
            _context = context;
        }

        public IProfessionalRepo professional  // c'est un singleton 
        {
            get
            {
                if (_professional==null)
                {
                   _professional =  new ProfessionalRepo(_context);
                }

                return _professional;
            }
        }

        public ICustomersRepo Customers
        {
            get
            {
                if (_customer==null)
                {
                    _customer =  new CustomersRepo(_context);
                }

                return _customer;
            }
        }

        public ICategoriesRepo categorie
        {
            get
            {
                if (_categorie==null)
                {
                    _categorie =  new CategoriesRepo(_context);
                }

                return _categorie;
            }
        }
        public IServicesRepo service {
            get { return _service ??= new ServicesRep(_context); }}

        public IInvoiceRepo invoice
        {
            get
            {
                if (_invoice==null)
                {
                    _invoice =  new InvoicesRepo(_context);
                }

                return _invoice;
            }
        }

        public IInvoiceLinesRepo invoicelines
        {
            get
            {
                if (_invoicelines==null)
                {
                    _invoicelines =  new InvoiceLinesRepo(_context);
                }

                return _invoicelines;
            }
        }

        public IPlanningsRepo planning
        {
            get
            {
                if (_planning==null)
                {
                    _planning =  new PlanningsRepo(_context);
                }

                return _planning;
            }
        }

        public IReservationsRepo reservation
        {
            get
            {
                if (_reservation==null)
                {
                    _reservation =  new ReservationsRepo(_context);
                }

                return _reservation;
            }
        }
        public IStatusRepo status { get
        {
            if (_status==null)
            {
                _status =  new StatusRepo(_context);
            }

            return _status;
        }}

        public IProfessionalServiceRepo ProfessionalServices
        {
            get
            {
                if (_professionalServices==null)
                {
                    _professionalServices =  new ProfessionalServiceRepo(_context);
                }

                return _professionalServices;
            }
        }

        public IDisponibilityRepo Disponibility
        {
            get
            {
                if (_disponibility==null)
                {
                    _disponibility =  new DisponibilityRepo(_context);
                }

                return _disponibility;
            }
            
        }
    }
}