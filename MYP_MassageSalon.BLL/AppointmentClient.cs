using AutoMapper;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.DAL.Dtos;
using MYP_MassageSalon.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYP_MassageSalon.DAL.IRepositories;
using MYP_MassageSalon.BLL.Mapping;

namespace MYP_MassageSalon.BLL
{
    public class AppointmentClient
    {
        private AppointmentnRepository _appRepository;
        private Mapper _mapper;

        public AppointmentClient()
        {
            _appRepository = new AppointmentnRepository();

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AppointmentMappingProfile()); 
            });
            _mapper = new Mapper(config);
        }
        public List<AppointmentsOutputModel> GetAllAppointmentsMap()
        {
            List<WorkersDTO> appDtos = _appRepository.GetAllAppointments();

            var result = _mapper.Map<List<AppointmentsOutputModel>>(appDtos);

            return result;
        }

        public List<AppointmentsAdminOutputModel> GetAllAppointmentsAdminMap()
        {
            List<WorkersDTO> appDtos = _appRepository.GetAllAppointments();

            var result = _mapper.Map<List<AppointmentsAdminOutputModel>>(appDtos);

            return result;
        }


    }
}
