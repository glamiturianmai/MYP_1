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
    public class ServiceRepository : IServiceRepository
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



        public void SetService(ServicesDTO service) //добавляем услугу по имя цена время 
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                connection.Query(ServiceStoredProcedures.SetService,
                    new { service.Name, service.Price, service.Time},
                    commandType: CommandType.StoredProcedure);
            }
        }



        //тут явно не все ок 
        public List<ServicesDTO> GetAllServicesNameWithType() //не одна табличка -  выводим все услуги это связь многие ко многим мы НЕ ЗНАЕМ что это такое 
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                return connection.Query<ServicesDTO, ServTypePrDTO, ServicesDTO>(
                    ServiceStoredProcedures.GetAllServicesName,
                    (service, servtype) =>
                    {
                        service.ServType.Add(servtype);
                        return service;
                    },
                    splitOn: "TypeId",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public List<ServicesDTO> GetAllServicesName()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                return connection.Query<ServicesDTO>(ServiceStoredProcedures.GetAllServicesName).ToList();
            }
        }
    }

    
}
