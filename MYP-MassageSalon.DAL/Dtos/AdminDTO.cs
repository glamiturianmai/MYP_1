namespace MYP_MassageSalon.DAL.Dtos;

public class AdminDTO
{
  public int Id { get; set; }

  public string Username { get; set; }

  public int? IPInf { get; set; }
  public int? Workers { get; set; }
  public int? Services { get; set; }
  public int? Appointment { get; set; }

  public bool IsDeleted { get; set; }
}
