using AutoMapper;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.DAL.Dtos;
using MYP_MassageSalon.DAL;
using MYP_MassageSalon.BLL.Mapping;
using MYP_MassageSalon.BLL.Models.InputModels;

namespace MYP_MassageSalon.BLL
{
    public class WorkerClient
    {
        private int _intervalDuration = 15;
        private int _shiftStart = 9;
        private int _shiftEnd = 22;

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

        public List<IntervalsOutputModel> GetScheduleIntervalsForWorkersMap(int id1)
        {
            List<SheduleIntervalDTO> workDtos = _intRepository.GetScheduleIntervalsForWorkers(id1);

            var result = _mapper.Map<List<IntervalsOutputModel>>(workDtos);

            return result;
        }

        public Dictionary<string, List<IntervalsOutputModel>> CheckOutIntervals(int serviceDuration, int workerId)
        {
            List<IntervalsOutputModel> dates = GetScheduleIntervalsForWorkersMap(workerId);
            Dictionary<string, List<IntervalsOutputModel>> intervals =
                new Dictionary<string, List<IntervalsOutputModel>>();

            int count = serviceDuration / _intervalDuration;
            for (int i = 0; i < dates.Count; i++)
            {
                int end_ind = i + count - 1;
                if (end_ind < dates.Count)
                {
                    string day1 = dates[i].Date.ToString("d");
                    string day2 = dates[end_ind].Date.ToString("d");

                    if (dates[i].Id + count - 1 == dates[end_ind].Id
                        && day1.Equals(day2))
                    {
                        if (!intervals.ContainsKey(day1))
                        {
                            intervals.Add(day1, new List<IntervalsOutputModel>());
                        }
                        intervals[day1].Add(dates[i]);
                    }
                }
            }

            return intervals;
        }


        public void DeleteWorkerMap(DeleteWorkerInputModel work)
        {
            WorkersDTO workMod = this._mapper.Map<WorkersDTO>(work);
            this._workRepository.DeleteWorker(workMod);

        }

        public void SetWorkerQualificationMap(QualifWorkerInputModels work)
        {
            WorkersDTO workMod = this._mapper.Map<WorkersDTO>(work);
            this._workRepository.SetQualificationWorker(workMod);

        }

        public List<QualificationsOutputModel> GetQualifWorker()
        {
            List<QualificationDTO> workDtos = _workRepository.GetQualifWorker();

            var result = _mapper.Map<List<QualificationsOutputModel>>(workDtos);

            return result;
        }

        public void AddNewWorkerMap(WorkersAddInputModel work)
        {
            WorkersDTO workMod = this._mapper.Map<WorkersDTO>(work);
            this._workRepository.AddNewWorker(workMod);

        }

        public void SetScheduleIntervalMap(IntervalIntputModel work)
        {
            IntervalPrDTO workMod = this._mapper.Map<IntervalPrDTO>(work);
            this._intRepository.SetScheduleInterval(workMod);

        }

        //public List<QualificationsOutputModel> GetQualifWorker()
        //{
        //    List<QualificationDTO> workDtos = _workRepository.GetQualifWorker();

        //    var result = _mapper.Map<List<QualificationsOutputModel>>(workDtos);

        //    return result;
        //}

        public List<WorkerINameOutputModel> GetWorkerNameByIdMap(WorkerIdInputModel work)
        {
            WorkersDTO workMod = this._mapper.Map<WorkersDTO>(work);
            List<WorkersDTO> w = this._workRepository.GetWorkerNameById(workMod);


            var result = _mapper.Map<List<WorkerINameOutputModel>>(w);

            return result;
        }

        public void SetSchedule(string date1, int workerId)
        {
            string[] dateParts = date1.Split('-');
            DateTime date = new DateTime(Int32.Parse(dateParts[0]), Int32.Parse(dateParts[1]), Int32.Parse(dateParts[2]), 00, 00, 00);

            IntervalIntputModel im = new IntervalIntputModel { WorkerId = workerId };
            int addHours = _shiftStart;
            int addMinutes = 0;
            date = date.AddHours(addHours);

            while ((addHours != _shiftEnd - 1) || (addMinutes != 60 - _intervalDuration))
            {
                date = date.AddMinutes(_intervalDuration);

                im.Date = date;
                SetScheduleIntervalMap(im);

                addMinutes += _intervalDuration;
                if (addMinutes == 60)
                {
                    addMinutes = 0;
                    addHours += 1;
                }
            }
        }
    }
}
