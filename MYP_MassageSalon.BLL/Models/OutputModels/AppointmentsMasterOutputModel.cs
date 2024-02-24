
using MYP_MassageSalon.DAL.Dtos;

namespace MYP_MassageSalon.BLL.Models.OutputModels;

public class AppointmentsMasterOutputModel
{
  public int Id { get; set; }

  public List<WorkerAppointmentsDTO>? WorksApp { get; set; }
}
