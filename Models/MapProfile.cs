using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using M= HouseCleanersApi.Models;
using D=HouseCleanersApi.Data;

namespace HouseCleanersApi.Models
{
    public class MapProfile: Profile
    {

        public MapProfile()
        {
            CreateMap<D.Categorie, M.Category>().ReverseMap();
            CreateMap<D.Customer, M.Customer>().ReverseMap();
            CreateMap<D.Invoice, M.Invoice>().ReverseMap();
            CreateMap<D.Planning, M.Planning>().ReverseMap();
            CreateMap<D.Professional, M.Professional>().ReverseMap();
            CreateMap<D.Reservation, M.Reservation>().ReverseMap();
            CreateMap<D.Roles, M.Roles>().ReverseMap();
            CreateMap<D.Service, M.Service>().ReverseMap();
            CreateMap<D.Status, M.Status>().ReverseMap();
            CreateMap<D.User, M.User>().ReverseMap();
            CreateMap<D.InvoiceLine, M.InvoiceLine>();
            CreateMap<D.ProfessionalService, M.ProfessionalService>().ReverseMap();
            CreateMap<ProfessionalCreateUpdateModel, D.Professional>();
            CreateMap<CustomerCreateUpdateModel, D.Customer>();
            CreateMap<InvoiceCreateUpdateModel, D.Invoice>();
            CreateMap<InvoiceCreateUpdateModel, D.Invoice>();
            CreateMap<ReservationCreateUpdateModel, D.Reservation>();
            CreateMap<ServiceCreateUpdateModes, D.Service>();
            

        }
        
    }
}
