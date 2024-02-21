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
    public class WorkerClient
    {
        private WorkersRepository _workRepository;
        private Mapper _mapper;

        public WorkerClient()
        {
            _workRepository = new WorkersRepository();

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new WorkersMappingProfile()); //пожалуйста возьми вот этот профиль 
            });
            _mapper = new Mapper(config);
        }

        public List<WorkersOutputModel> GetWorkersByServiceIdMap(int id1)
        {
            List<WorkersDTO> workDtos = _workRepository.GetWorkersByServiceId(id1);

            var result = _mapper.Map<List<WorkersOutputModel>>(workDtos); //преобразуй список dto в список моделек 

            return result;
        }

       


    }
}
