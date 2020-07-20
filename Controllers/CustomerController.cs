using System.Linq;
using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using HouseCleanersApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HouseCleanersApi.Data;
using M=HouseCleanersApi.Models;

namespace HouseCleanersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IGeneralRepository _repository;
        private readonly IMapper _mapper;

        public CustomerController(IGeneralRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region reservation

     
        //reservation
        [HttpPost]
        [Route("AddReservation")]
        public IActionResult AddReservation([FromBody] M.ReservationCreateUpdateModel reservation)
        {
            var data = _mapper.Map<Reservation>(reservation);
            
            data.statusId = 1;
            return Ok(_repository.reservation.Create(data));
        }
        [HttpPut]
        [Route("UpdateReservation")]
        public IActionResult UpdateReservation( M.ReservationCreateUpdateModel reservation)
        {
            if (_repository.reservation.FindByCondition(res=>res.reservationId==reservation.reservationId)==null)
            {
                return NotFound();
            }
            var result= _repository.reservation.Update(_mapper.Map<Reservation>(reservation));
            return Ok(result);
        }
        [HttpDelete]
        [Route("CancelReservation")]
        public IActionResult CancelReservation( M.Reservation reservation)
        {  
            if (_repository.reservation.FindByCondition(res=>res.reservationId==reservation.reservationId)==null)
            {
                return NotFound();
            }
            
            var result= _repository.reservation.Delete(_mapper.Map<Reservation>(reservation));
            return Ok(result);
        }   

        #endregion
        
        #region billing
        
        //billing
        [HttpGet]
        [Route("GetInvoices/{customerId}")]
        public IActionResult GetInvoices(int customerId)
        {
            return new ObjectResult(_repository.invoice.GetAll());

        }
        [HttpGet]
        [Route("GetOneInvoices/{id}")]
        public IActionResult GetOneInvoices(int id)
            => new ObjectResult(_repository.invoice.FindByCondition(i=>i.invoiceId==id));


        [HttpPost]
        [Route("CreateInvoice")]
        public IActionResult CreateInvoice([FromBody]M.InvoiceCreateUpdateModel invoice)
        { if (invoice.invoiceLines==null)
            {
                return BadRequest("no invoiceLines");
            }
            
            var model = _mapper.Map<Invoice>(invoice);
           
            int id=  _repository.invoice.CreateInvoice(model); 
            foreach (var i in invoice.invoiceLines)
            {
                i.invoiceId = id;
            }

            model.invoiceAmountTotal = model.invoiceLines.Sum(i => i.amount);

            _repository.invoicelines.CreateMany(model.invoiceLines);
            return new ObjectResult(_mapper.Map<M.Invoice>(model));
        }
        #endregion
        
        #region Infos customer
    [HttpPut] 
    [Route("UpdateInfos")]
    public IActionResult UpdateInfos([FromBody]M.CustomerCreateUpdateModel customer)
        {
            if (_repository.Customers.FindByCondition(res=>res.customerId==customer.customerId)==null)
            {
                return NotFound();
            }
           return new ObjectResult(_repository.Customers.Update(_mapper.Map<Customer>(customer)));
        }
        #endregion
    }
}