using AutoMapper;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.DAL.Dtos;
using MYP_MassageSalon.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYP_MassageSalon.BLL.Mapping;

namespace MYP_MassageSalon.BLL
{
    public class QualificationTypeClient
    {
        private ClientRepository _clientRepository;
        private Mapper _mapper;

        public QualificationTypeClient()
        {
            _clientRepository = new ClientRepository();

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new WorkersMappingProfile()); //пожалуйста возьми вот этот профиль 
            });
            _mapper = new Mapper(config);
        }

        public List<QualificationWorkersOutputModel> GetALLQualificationMap()
        {
            List<QualificationDTO> servDtos = _clientRepository.GetALLQualification();

            var result = _mapper.Map<List<QualificationWorkersOutputModel>>(servDtos); //преобразуй список dto в список моделек 

            return result;
        }

        public List<TypeOutputModel> GetALLTypeMap()
        {
            List<TypeDTO> servDtos = _clientRepository.GetALLType();

            var result = _mapper.Map<List<TypeOutputModel>>(servDtos); //преобразуй список dto в список моделек 

            return result;
        }


    }
}
