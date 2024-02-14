using MYP_MassageSalon.DAL.IRepositories;
using System;
using MYP_MassageSalon.DAL.Dtos;
using MYP_MassageSalon.DAL.StoredProcedures;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using MYP_MassageSalon.DAL;


namespace MYP_MassageSalon.DAL
{
    public class AppointmentnRepository: IAppointmentnRepository
    {
        public void AddAppointment(AppointmentDTO appointment) //ГЛОБАЛЬНО добавляем заявку (заводим по id клиента)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                connection.Query(AppointmentStoredProcedures.AddAppointment,
                    new { appointment.ClientId},
                    commandType: CommandType.StoredProcedure); //тип подключения ??
            }
        }

        public void AddService_Appointment(Service_AppointmentDTO serviceappointment) //добавляем заявку по услуге 
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                connection.Query(AppointmentStoredProcedures.AddService_Appointment,
                    new { serviceappointment.ServicesId, serviceappointment.AppointmentId, serviceappointment.WorkerId, serviceappointment.Price },
                    commandType: CommandType.StoredProcedure); //тип подключения ??
            }
        }

        public void DeleteAppointment(AppointmentDTO app) //удаляем заявку по id
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                connection.Query(AppointmentStoredProcedures.DeleteAppointment,
                    new { app.Id },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<WorkersDTO> GetAllAppointments() //заявки    
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                return connection.Query<WorkersDTO, WorkerAppointmentsDTO, WorkersDTO>(
                    AppointmentStoredProcedures.GetAllAppointments,
                    (worker, workapp) =>
                    {
                        worker.WorksApp.Add(workapp);
                        return worker;

                    },
                    
                    splitOn: "Date",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }
        }
    }
}

