using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using M= HouseCleanersApi.Models;


namespace HouseCleanersApi.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IGeneralRepository _repository;
        private readonly IMapper _mapper;

        public HomeController(IGeneralRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
          [HttpGet]
          [Route("Categories")]
          public IActionResult GetAllCategories()
          {
              return new ObjectResult(_mapper.Map<M.Category>(_repository.categorie.GetAll()));
          }
          

          [HttpGet]
          [Route("Category/id")]
          public IActionResult GetOneCategories(int id)
          {
              return new ObjectResult(_mapper.Map<M.Category>(_repository.categorie.FindByCondition(x=>x.categoryId==id)));
          }

          [HttpGet]
          [Route("Professionals")]
          public IActionResult GetAllProfessionals()
          {
              return new ObjectResult(_mapper.Map<IEnumerable<M.Professional>>(_repository.professional.GetAllProfessionnal()));
          }

          [HttpGet]
          [Route("ProfessionalsByService")]
          public IActionResult ProfessionalsByService(int serviceId)
          {
              return new ObjectResult(_mapper.Map<IEnumerable<M.Professional>>(_repository.professional.ProfessionalByService(serviceId).ToList()));
          }

          [HttpGet]
          [Route("Professional/id")]
          public IActionResult GetOneProfessionals(int id)
          {
              return  new ObjectResult (_mapper.Map<M.Professional>(_repository.professional.FindByCondition(x=>x.professionalId==id)));
          }
          
          [HttpGet]
          [Route("Professionals/postCode")]
          public IActionResult GetProfessionalsAddress(int PostCode)
          {
              return  new ObjectResult (_mapper.Map<M.Professional>(_repository.professional.FindByCondition(x=> x.postCode == PostCode)));
          }
          [HttpGet]
          [Route("Professionals/name")]
          public IActionResult GetProfessionalsAddress(string name)
          {
              return  new ObjectResult (_mapper.Map<M.Professional>(_repository.professional.FindByCondition(x=> x.firstName.Contains(name)||x.lastName.Contains(name))));
          }
          
          //services
          
           //Services
                  [HttpGet]
                  [Route("Services")]
                  public IActionResult GetAllServices()
                  {
                      var services = _mapper.Map<IEnumerable<M.Service>>(_repository.service.GetAll());
                      return new ObjectResult(services);
                  }
          
                  [HttpGet]
                  [Route("ServicesByCategory")]
                  public IActionResult GetServiceByCategory(int categoryId)
                  {
                      var dbresult = _repository.service.FindByCondition(x => x.categoryId == categoryId).FirstOrDefault();
                      var result = _mapper.Map<M.Service>(dbresult);
                      return new ObjectResult(result);
                  }
          
                  [HttpGet]
                  [Route("ServicesByProfessional")]
                  public IActionResult GetServiceByProfessional(int professionalId)
                  {
                      var dbResult = _repository.service.ServicesByProfessionnal(professionalId).ToList();
                      var result = _mapper.Map<IEnumerable<M.Service>>(dbResult);
          
                      return new ObjectResult(result);
                  }
                  
                  [HttpGet]
                  [Route("Services/{id}")]
                  public IActionResult GetOneServices(int id)
                  {
                      var services = _mapper.Map<IEnumerable<M.Service>>(_repository.service.FindByCondition(s=>s.serviceId==id));
                      return new ObjectResult(services); 
                  }
                  
                  #region Planning
                  [HttpGet]
                  [Route("GetPlanningProfessionnal")]
                  public IActionResult GetPlanningProfessionnal(int professionalId)
                  {
                     var planning= _repository.planning.FindByCondition(pl => pl.professionalId == professionalId).FirstOrDefault();
                     if (planning==null)
                     {
                         return NotFound("no planning for this porfessional");
                     }
                    var hours=new List<int>();
                     var count = planning.startHour.Hour;

                     while (count<=planning.endHour.Hour)
                     {
                         hours.Add(count);
                         count++;
                     }

                     return new ObjectResult(hours);
                  }
                  
                  #endregion

    }
    
}