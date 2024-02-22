using MYP_MassageSalon.DAL.Dtos;

namespace MYP_MassageSalon.DAL;

public interface IAdminRepositories
{
  public List<AdminDTO> GetAllAdmins();

  public List<QualificationDTO> GetALLQualification();

  public List<TypeDTO> GetALLType();

  public List<ClientsDTO> GetClientsAppointments(int Id1); 
}