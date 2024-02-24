using AutoMapper;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.DAL.Dtos;
using MYP_MassageSalon.BLL.Models.InputModels;

namespace MYP_MassageSalon.BLL.Mapping
{
  public class AppointmentMappingProfile : Profile
    {
        public AppointmentMappingProfile()
        {
            CreateMap<DeleteAppIntputModel, AppointmentDTO>();

            CreateMap<AppointmentIntputModel, AppointmentDTO>(); //Пожалуйста преобразуй 
            CreateMap<Service_AppointmentDTO, Service_AppointmentIntputModel>();



            CreateMap<WorkersDTO, AppointmentsOutputModel>(); //Пожалуйста преобразуй 
            CreateMap<WorkersDTO, AppointmentsMasterOutputModel>(); 
            CreateMap<WorkersDTO, AppointmentsAdminOutputModel>();

            CreateMap<ClientAppPrDTO, ClientAppPrOutputModel>();
            CreateMap<ClientsDTO, AppointmentsOutputModel>()
                .ForMember(a=>a.WorksApp, o=>o.MapFrom(b=>b.ClientApp)); 
            
        }
    }
}
