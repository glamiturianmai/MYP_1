using AutoMapper;
using MYP_MassageSalon.BLL.Mapping;
using MYP_MassageSalon.BLL.Models.InputModels;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.DAL;
using MYP_MassageSalon.DAL.Dtos;

namespace MYP_MassageSalon.BLL;

public class AppointmentClient
{
    private AppointmentnRepository _appRepository;
    private ClientRepository _cliRepository;
    private ScheduleIntervalRepository _scheduleIntervalRepository;
    private Mapper _mapper;

    public AppointmentClient()
    {
        _appRepository = new AppointmentnRepository();
        _cliRepository = new ClientRepository();
        _scheduleIntervalRepository = new ScheduleIntervalRepository();

        var config = new MapperConfiguration(cfg =>
        {
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

    public List<AppointmentsMasterOutputModel> GetAllAppointmentsMasterMap()
    {
        List<WorkersDTO> appDtos = _appRepository.GetAllAppointments();

        var result = _mapper.Map<List<AppointmentsMasterOutputModel>>(appDtos);

        return result;
    }

    public List<AppointmentsOutputModel> GetClientsAppointmentsMap(int id)
    {
        List<ClientsDTO> appDtos = _cliRepository.GetClientsAppointments(id);

        var result = _mapper.Map<List<AppointmentsOutputModel>>(appDtos);

        return result;
    }

    private List<ClientAppPrOutputModel> GetClientsAppointmentsMapSortedSecond(List<AppointmentsOutputModel> a)
    {
        List<ClientAppPrOutputModel> list1 = new List<ClientAppPrOutputModel>();

        if (a.Count != 0)
        {
            var apps = a[0].WorksApp;
            int lengthinterval = 15;

            var timestart = apps[0].Date.TimeOfDay; //


            for (int i = 0; i < apps.Count; i++)
            {
                var n = apps[i].Duration / lengthinterval;
                list1.Add(apps[i]);
                i += n - 1;
                list1.Add(apps[i]);
            }
        }

        return list1;

    }

    public List<ClientAppPrOutputModel> GetPlease(int Id)
    {
        var a = GetClientsAppointmentsMap(Id);
        var b = GetClientsAppointmentsMapSortedSecond(a);
        return b;
    }



    public List<AppointmentsAdminOutputModel> GetAllAppointmentsAdminMap()
    {
        List<WorkersDTO> appDtos = _appRepository.GetAllAppointments();

        var result = _mapper.Map<List<AppointmentsAdminOutputModel>>(appDtos);

        return result;
    }

    public void DeleteAppointmentMap(DeleteAppIntputModel app)
    {
        AppointmentDTO appMod = this._mapper.Map<AppointmentDTO>(app);
        this._appRepository.DeleteAppointment(appMod);

    }

    public int AddAppointmentMap(AddAppClientIntputModel app)
    {
        AppointmentDTO appMod = this._mapper.Map<AppointmentDTO>(app);

        return this._appRepository.AddAppointment(appMod)[0].Id;
    }

    public void AddService_AppointmentMap(AddAppIntputModel app)
    {
        Service_AppointmentDTO appMod = this._mapper.Map<Service_AppointmentDTO>(app);
        this._appRepository.AddService_Appointment(appMod);

    }

    public int intervalDuration = 15;
    public void SetAppointment(int clientId, int serviceId, int workerId, 
                                int serviceDuration, int intervalId, decimal price)
    {
        var a = new AddAppClientIntputModel
        {
            ClientId = clientId
        };
        int appId = AddAppointmentMap(a);

        var serviceInApp = new AddAppIntputModel
        {
            ServiceId = serviceId,
            WorkerId = workerId,
            AppId = appId,
            ServicePrice = price,
            ClientId = clientId
        };
        AddService_AppointmentMap(serviceInApp);

        SetIntervals(intervalId, serviceDuration, appId);
    }

    public void SetIntervals(int intervalId, int serviceDuration, int appId )
    {
        int numberOfIntervals = serviceDuration / intervalDuration;
        
        for (int i = 0; i <  numberOfIntervals; i++)
        {
            _scheduleIntervalRepository.SetAppointmnetInInterval(intervalId + i, appId);
        }
    }

    public List<IntervalIdOutputModel> GetIntervalDateByIdMap(IntervalIdInputModel work)
    {
        SheduleIntervalDTO workMod = this._mapper.Map<SheduleIntervalDTO>(work);
        List<SheduleIntervalDTO> w = this._scheduleIntervalRepository.GetIntervalDateById(workMod);


        var result = _mapper.Map<List<IntervalIdOutputModel>>(w);

        return result;
    }
}
