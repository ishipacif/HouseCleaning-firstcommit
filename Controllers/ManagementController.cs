using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HouseCleanersApi.Interfaces;
using HouseCleanersApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using HouseCleanersApi.Data;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using M=HouseCleanersApi.Models;
using D=HouseCleanersApi.Data;



namespace HouseCleanersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        private readonly UserManager<D.User> _userManager;
        private readonly SignInManager<D.User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IGeneralRepository _repository;
        private readonly IConfiguration _config;
        
        
        public ManagementController( UserManager<D.User> userManager, IGeneralRepository repository, SignInManager<D.User>signInManager, IConfiguration config,IMapper mapper)
        {
           _userManager = userManager ;
           _signInManager = signInManager;
          _config = config;
           _repository = repository;
           _mapper = mapper;
        }

        [HttpPost]
        [Route("CreateProfessional")]
        public async Task<IActionResult> CreateProfessional(ProfessionalCreateUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            D.User user = new D.User()
            {
                firstName = model.firstName,
                lastName = model.lastName,
                Email = model.email,
                UserName = model.email,
                PhoneNumber = model.phoneNumber
            };
            var result = await _userManager.CreateAsync(user, model.password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "professionals");
                 
                var professional = _mapper.Map<D.Professional>(model);
                professional.user = _mapper.Map<D.User>(user);
                var cus = _repository.professional.Create(professional);
                ;
                if (cus==null)
                {
                   await _userManager.DeleteAsync(user);
                    return BadRequest();
                }
               
                return Ok();

            }

            else
            {
                return new ObjectResult(result.Errors);
            }
        }
        
        

[HttpPost]
[Route("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(CustomerCreateUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                D.User user = new D.User()
                {
                    firstName = model.firstName,
                    lastName = model.lastName,
                    Email = model.email,
                    UserName = model.email,
                    PhoneNumber = model.phoneNumber,
                };
                var result = await _userManager.CreateAsync(user, model.password);
                    if (result.Succeeded)
                    { 
                        await _userManager.AddToRoleAsync(user, "customers");
                        var customer = _mapper.Map<D.Customer>(model);
                        customer.user = user;
                       var cus= _repository.Customers.Create(customer);
                       if (cus==null)
                       {
                           await _userManager.DeleteAsync(user);
                           return BadRequest();
                       }
                        return Ok();

                    }
                    else
                    {
                        
                        return new ObjectResult(result.Errors);
                    }
            }
        }


       [HttpPost]
        [Route("LogIn")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.email, model.password, true, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.email);
                var role = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
                    
                 // create token
                 var claims = new[]
                 {
                     new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                     new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                     new Claim(ClaimTypes.Name, user.Id),
                     new Claim(ClaimTypes.Role, role)
                 };
                     var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:key"]));
                                                 var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                                                 var token = new JwtSecurityToken(
                                                     _config["Tokens:Issuer"],
                                                     _config["Tokens:Audience"],
                                                     claims,
                                                     expires: DateTime.Now.AddMinutes(20),
                                                     signingCredentials: creds
                                                     );
                                                 var results = new
                                                 {
                     
                                                     token = new JwtSecurityTokenHandler().WriteToken(token),
                                                     expiration = token.ValidTo
                                                 };
                                                 return Created("", results);
            }
            else
            {
                
                return BadRequest(result);
            }
           
        }
        
       [ HttpGet]
        [Route("Logout")]
       public async Task<IActionResult>Logout()
       {
           await _signInManager.SignOutAsync();
           return Ok();
       }
    }
}