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
        private int intervalDuration = 15;

        private WorkersRepository _workRepository;
        private ScheduleIntervalRepository _intRepository;
        private Mapper _mapper;

        public WorkerClient()
        {
            _workRepository = new WorkersRepository();
            _intRepository = new ScheduleIntervalRepository();

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new WorkersMappingProfile()); 
            });
            _mapper = new Mapper(config);
        }

        public List<WorkersOutputModel> GetWorkersByServiceIdMap(int id1)
        {
            List<WorkersDTO> workDtos = _workRepository.GetWorkersByServiceId(id1);

            var result = _mapper.Map<List<WorkersOutputModel>>(workDtos); 

            return result;
        }

        public List<WorkersAllOutputModel> GetAllWorkerMap()
        {
            List<WorkersDTO> workDtos = _workRepository.GetAllWorker();

            var result = _mapper.Map<List<WorkersAllOutputModel>>(workDtos); 

            return result;
        }




    }
}
