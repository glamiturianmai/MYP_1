using Microsoft.Data.SqlClient;
using MYP_MassageSalon.DAL.Dtos;
using MYP_MassageSalon.DAL.IRepositories;
using MYP_MassageSalon.DAL.StoredProcedures;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MYP_MassageSalon.DAL
{
    public class ServiceRepository: IServiceRepository
    {
        public void DeleteService(ServicesDTO service) //удаляем услугу по id
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                connection.Query(ServiceStoredProcedures.DeleteService,
                    new { service.Id },
                    commandType: CommandType.StoredProcedure); 
            }
        }
    }
}
