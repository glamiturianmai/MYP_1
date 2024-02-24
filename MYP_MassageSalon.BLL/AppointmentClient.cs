using AutoMapper;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.DAL.Dtos;
using MYP_MassageSalon.DAL;
using MYP_MassageSalon.BLL.Mapping;
using MYP_MassageSalon.BLL.Models.InputModels;

namespace MYP_MassageSalon.BLL;

public class AppointmentClient
{
  private AppointmentnRepository _appRepository;
  private ClientRepository _cliRepository;
  private Mapper _mapper;

  public AppointmentClient()
  {
    _appRepository = new AppointmentnRepository();
    _cliRepository = new ClientRepository();

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
    var apps = a[0].WorksApp;
    int lengthinterval = 15;

    var timestart = apps[0].Date.TimeOfDay; //

    List<ClientAppPrOutputModel> list1 = new List<ClientAppPrOutputModel>();
    for (int i = 0; i < apps.Count; i++)
    {
      var n = apps[i].Duration / lengthinterval;
      list1.Add(apps[i]);
      i += n - 1;
      list1.Add(apps[i]);
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

}
