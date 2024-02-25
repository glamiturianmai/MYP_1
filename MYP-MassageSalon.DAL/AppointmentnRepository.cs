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

        public int SetAppointment(Service_AppointmentDTO serviceappointment) //добавляем заявку по услуге 
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                connection.Query(AppointmentStoredProcedures.SetAppointment,
                    new { serviceappointment.ClientId, serviceappointment.WorkerId, serviceappointment.ServiceId, serviceappointment.ServicePrice },
                    commandType: CommandType.StoredProcedure);

                return serviceappointment.AppId;
            }
        }





        public List<AppointmentDTO> AddAppointment(AppointmentDTO appointment) //ГЛОБАЛЬНО добавляем заявку (заводим по id клиента)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                return connection.Query<AppointmentDTO>(AppointmentStoredProcedures.AddAppointment,
                    new { appointment.ClientId},
                    commandType: CommandType.StoredProcedure).ToList(); //тип подключения ??
              
            }
        }

        public void AddService_Appointment(Service_AppointmentDTO serviceappointment) //добавляем заявку по услуге 
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                 connection.Query(AppointmentStoredProcedures.AddService_Appointment,
                    new { serviceappointment.ServiceId, serviceappointment.WorkerId, serviceappointment.ServicePrice},
                    commandType: CommandType.StoredProcedure);

                
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

