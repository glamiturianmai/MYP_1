using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MYP_MassageSalon.BLL.Mapping;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.DAL;
using MYP_MassageSalon.DAL.Dtos;
using MYP_MassageSalon.DAL.IRepositories;
using AutoMapper;
using MYP_MassageSalon.BLL.Models.InputModels;


namespace MYP_MassageSalon.BLL
{
    public class ServiceClient
    {
        private ServiceRepository _serviceRepository;
        private Mapper _mapper;

        public ServiceClient()
        {
            _serviceRepository = new ServiceRepository();

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new ServiceMappingProfile()); //пожалуйста возьми вот этот профиль 
            });
            _mapper = new Mapper(config);
        }

        public List<ServiceOutputModel> GetAllServicesNameMap()
        {
            List<ServicesDTO> servDtos = _serviceRepository.GetAllServicesName();

            var result = _mapper.Map<List<ServiceOutputModel>>(servDtos); //преобразуй список dto в список моделек 

            return result;
        }

        public List<ServiceAdminOutputModel> GetAllServicesMap()
        {
            List<ServicesDTO> servDtos = _serviceRepository.GetAllServices();

            var result = _mapper.Map<List<ServiceAdminOutputModel>>(servDtos); //преобразуй список dto в список моделек 

            return result;
        }


        public void SetServiceMap(ServiceIntputModel work)
        {
            ServicesDTO workMod = this._mapper.Map<ServicesDTO>(work);
            this._serviceRepository.SetService(workMod);

        }

        public void DeleteServiceMap(DeleteServiceInputModel work)
        {
            ServicesDTO workMod = this._mapper.Map<ServicesDTO>(work);
            this._serviceRepository.DeleteService(workMod);

        }

        public List<ServiceNameOutputModel> GetServiceNameByIdMap(ServiceIdInputModel work)
        {
            ServicesDTO workMod = this._mapper.Map<ServicesDTO>(work);
            List<ServicesDTO> w = this._serviceRepository.GetServiceNameById(workMod);


            var result = _mapper.Map<List<ServiceNameOutputModel>>(w);

            return result;
        }

    }
}
