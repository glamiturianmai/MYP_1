using AutoMapper;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYP_MassageSalon.BLL.Models.InputModels;
using MYP_MassageSalon.BLL.Models.OutputModels;

namespace MYP_MassageSalon.BLL.Mapping
{
    public class AppointmentMappingProfile : Profile
    {
        public AppointmentMappingProfile()
        {
            CreateMap<AppointmentDTO, AppointmentIntputModel>(); //Пожалуйста преобразуй 
            CreateMap<Service_AppointmentDTO, Service_AppointmentIntputModel>();



            CreateMap<WorkersDTO, AppointmentsOutputModel>(); //Пожалуйста преобразуй 
            CreateMap<WorkersDTO, AppointmentsAdminOutputModel>();
        }
    }
}
