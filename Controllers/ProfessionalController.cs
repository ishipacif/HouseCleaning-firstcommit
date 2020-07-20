using System;
using System.Collections.Generic;
using AutoMapper;
using HouseCleanersApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using M=HouseCleanersApi.Models;
using HouseCleanersApi.Data;
using HouseCleanersApi.Helper;

namespace HouseCleanersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalController : ControllerBase
    {
        private readonly IGeneralRepository _repository;
        private readonly IMapper _mapper;


        public ProfessionalController(IGeneralRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region Service

        [HttpPost]
        [Route("AddServiceToProfessional")]
        public IActionResult AddServiceToProfessional([FromBody] M.ProfessionalService serprof)
        {

            var c = _repository.ProfessionalServices.Create(_mapper.Map<ProfessionalService>(serprof));
            return new ObjectResult(c);
        }

        #endregion

        #region Infos Professional

        [HttpPut]
        [Route("ModifyProfessional")]
        public IActionResult ModifyProfessional([FromBody] M.ProfessionalCreateUpdateModel prof)
        {
            if (_repository.professional.FindByCondition(p=>p.professionalId==prof.professionalId)==null)
            {
                return NotFound();
            }
            var c = _repository.professional.Update(_mapper.Map<Professional>(prof));
            return new ObjectResult(c);
        }
        [HttpDelete]
        [Route("DeleteProfessional")]
        public IActionResult DeleteProfessional(int id)
        {
            var professionel=_repository.professional.FindById(x=>x.professionalId==id);
            if (professionel==null)
            {
                return NotFound();
            }

            professionel.active = false;
            return new ObjectResult(_repository.professional.Update(professionel));
        }
        
        #endregion
        
         #region Reservation
        
                [HttpGet]
                [Route("Reservations")]
                public IActionResult GetAllReservations()
                {
                    return new ObjectResult(_mapper.Map<IEnumerable<M.Reservation>>(_repository.reservation.GetAll()));
                }
        
                [HttpGet]
                [Route("Reservation/{id}")]
                public IActionResult Reservation(int id)
                {
                    return new ObjectResult(_mapper.Map<M.Reservation>(_repository.reservation.FindById(x=>x.reservationId==id)));
                }
                
                //to do ajouter id professionnel (cfr lien associatif .net core) 
                [HttpGet]
                [Route("ReservationByCustomer/{customerid}")]
                public IActionResult ReservationByCustomer(int customerid)
                {
                   return new ObjectResult(_mapper.Map<IEnumerable<M.Reservation>>(_repository.reservation.FindByCondition(x => x.customerId == customerid)));
                }
                [HttpGet]
                [Route("ReservationByProfessional/{professionalid}")]
                public IActionResult ReservationByProfessional(int professionalid)
                {
                    return new ObjectResult(_mapper.Map<IEnumerable<M.Reservation>>(_repository.reservation.FindByCondition(x => x.professionalId == professionalid)));
                }

                [HttpPut]
                [Route("ValidateReservation/{reservationid}")]
                public IActionResult ValidateReservation(int reservationid)
                {
                    var data = _repository.reservation.FindById(x=>x.reservationId==reservationid);
                    if (data==null)
                    {
                        return NotFound();
                    }

                    data.statusId = 2;
                    return Ok(_repository.reservation.Update(data));
                }
                
                [HttpPut]
                [Route("RefusedReservation/{reservationid}")]
                public IActionResult RefusedReservation(int reservationid)
                {
                    var data = _repository.reservation.FindById(x=>x.reservationId==reservationid);
                    if (data==null)
                    {
                        return NotFound();
                    }

                    data.statusId = 3;
                    return Ok(_repository.reservation.Update(data));
                }

                 [HttpPost]
                 [Route("JobDone/{reservationid}")]
                 public IActionResult JobDone(int reservationid)
                 {
                     var myReservation = _repository.reservation.FindById(x=>x.reservationId==reservationid);
                     if (myReservation==null)
                     {
                         return NotFound();
                     }
                     myReservation.statusId = 4;
                     myReservation.Service = _repository.service.FindById(x=>x.serviceId==myReservation.ServiceId);
                    return new ObjectResult(_repository.invoicelines.Create(InvoiceManagement.GetInvoiceLine(myReservation)));
                    
                 }
                
                 
                #endregion
        
        #region Planning

        [HttpPost]
        [Route("Addplanning")]
        public IActionResult Addplanning([FromBody]M.Planning planning)
        {
            return new ObjectResult(_repository.planning.Create(_mapper.Map<Planning>(planning)));
        }

         [HttpGet] 
         [Route("GetPlanningProfessionnel")]
        public IActionResult GetPlanningProfessionnel(int professionnelid)
        {
            return new ObjectResult(_repository.planning.FindByCondition(p=>p.professionalId==professionnelid));
        }

        [HttpPost] 
         [Route("GenarateDisponibilities")]
        public IActionResult GenarateDisponibilities([FromBody] M.PlanningProfessional planning)
        {
            var dates = TimeManagement.planningDates(planning.startDate, planning.endDate, planning.saturday,
                planning.sunday);
            var disponibilities =
                TimeManagement.plannningHours(dates, planning.professionalId, planning.startHour, planning.endHour);
            return new ObjectResult(_repository.Disponibility.CreateMany(disponibilities)); 
        }
        
        #endregion
        
        
        

        
                
    }
}