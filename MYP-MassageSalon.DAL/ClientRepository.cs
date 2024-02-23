
using MYP_MassageSalon.DAL.IRepositories;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MYP_MassageSalon.DAL.StoredProcedures;
using MYP_MassageSalon.DAL.Dtos;
using static System.Formats.Asn1.AsnWriter;


namespace MYP_MassageSalon.DAL
{
    public class ClientRepository : IClientsRepositories
    {
        public List<ClientsDTO> GetAllClients()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                return connection.Query<ClientsDTO>(ClientsStoredProcedures.GetAllClients).ToList();
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



        public List<ClientsDTO> GetClientsAppointments(int Id1) //заявки id мастера - много табличек   
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                Dictionary<int, ClientsDTO> apps = new Dictionary<int, ClientsDTO>();
                var parametrs = new
                {
                    Id = Id1
                };

                return connection.Query<ClientsDTO, ClientAppPrDTO, ClientsDTO>(
                    ClientsStoredProcedures.GetClientsAppointments,
                    (client, clientapp) =>
                    {
                        if (!apps.ContainsKey(client.Id))
                        {
                            apps.Add((client.Id), client);
                        }

                        ClientsDTO crntShop = apps[client.Id];

                        crntShop.ClientApp.Add(clientapp);

                        return crntShop;
                    },
                    parametrs,
                    splitOn: "AppId",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public List<IpInfDTO> GetClientIdByIpInf(int IpInf1)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                var parametrs = new
                {
                    IpInf = IpInf1
                };
                return connection.Query<IpInfDTO>(ClientsStoredProcedures.GetClientIdByIpInf,
                    parametrs).ToList();
            }
        }

        public void AddClient(ClientsDTO client) 
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                connection.Query(ClientsStoredProcedures.AddClient,
                    new { client.Username, client.IPInf },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }

    
}
