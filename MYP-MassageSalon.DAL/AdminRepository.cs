﻿
using MYP_MassageSalon.DAL.IRepositories;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MYP_MassageSalon.DAL.StoredProcedures;
using MYP_MassageSalon.DAL.Dtos;


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



        public List<ClientsDTO> GetClientsAppointments(int Id1) //заявки id мастера - много табличек   
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                var parametrs = new
                {
                    Id = Id1
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
