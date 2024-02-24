using Dapper;
using Microsoft.Data.SqlClient;
using MYP_MassageSalon.DAL.Dtos;
using MYP_MassageSalon.DAL.StoredProcedures;
using System.Data;


namespace MYP_MassageSalon.DAL
{
  public class AdminRepository : IAdminRepositories
  {
    public List<AdminDTO> GetAllAdmins()
    {
      using (IDbConnection connection = new SqlConnection(Options.ConStr))
      {
        return connection.Query<AdminDTO>(ClientsStoredProcedures.GetAllClients).ToList();
      }
    }

    public List<QualificationDTO> GetALLQualification()
    {
      using (IDbConnection connection = new SqlConnection(Options.ConStr))
      {
        return connection.Query<QualificationDTO>(ClientsStoredProcedures.GetALLQualification).ToList();
      }
    }

    public List<TypeDTO> GetALLType()
    {
      using (IDbConnection connection = new SqlConnection(Options.ConStr))
      {
        return connection.Query<TypeDTO>(ClientsStoredProcedures.GetALLType).ToList();
      }
    }

    public List<ClientsDTO> GetClientsAppointments(int id) //заявки id мастера - много табличек   
    {
      using (IDbConnection connection = new SqlConnection(Options.ConStr))
      {
        var parametrs = new
        {
          Id = id
        };
        return connection.Query<ClientsDTO, ClientAppPrDTO, ClientsDTO>(
            ClientsStoredProcedures.GetClientsAppointments,
            (client, clientapp) =>
            {
              client.ClientApp.Add(clientapp);
              return client;
            },
            parametrs,
            splitOn: "IntervalId",
            commandType: CommandType.StoredProcedure
            ).ToList();
      }
    }
  }
}
