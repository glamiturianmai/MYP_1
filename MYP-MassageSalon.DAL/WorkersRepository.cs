using Dapper;
using Microsoft.Data.SqlClient;
using MYP_MassageSalon.DAL.Dtos;
using MYP_MassageSalon.DAL.IRepositories;
using MYP_MassageSalon.DAL.StoredProcedures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.DAL
{
    public class WorkersRepository: IWorkersRepository
    {
        public List<WorkersDTO> GetQualificationWorker(int Id1) //квалификация по id мастера - 2 таблички  
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                var parametrs = new
                {
                    WorkerId=Id1
                };
                return connection.Query<WorkersDTO, QualificationDTO, WorkersDTO>(
                    WorkersStoredProcedures.GetQualificationWorker,
                    (worker, qualification) =>
                    {
                        worker.QualificationWorker = qualification;
                        return worker;
                    },
                    parametrs,
                    splitOn: "QualificationId",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }
        }


        public List<WorkersDTO> GetWorkerAppointments(int Id1) //заявки id мастера - много табличек   
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                var parametrs = new
                {
                    WorkerId = Id1
                };
                return connection.Query<WorkersDTO, WorkerAppointmentsDTO, WorkersDTO>(
                    WorkersStoredProcedures.GetWorkerAppointments,
                    (worker, workerappointment) =>
                    {
                        worker.Appointments.Add(workerappointment);
                        return worker;
                        
                    },
                    parametrs,
                    splitOn: "Id,IntervalId",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public void DeleteWorker(WorkersDTO work) //удаляем сотрудника по id
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                connection.Query(WorkersStoredProcedures.DeleteWorker,
                    new { work.Id },
                    commandType: CommandType.StoredProcedure);
            }
        }


        public void AddNewWorker(WorkersDTO worker) //добавляем работника по ИМЕНИ КВАЛИФИКАЦИИ(ID) по услуге 
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                connection.Query(WorkersStoredProcedures.AddNewWorker,
                    new { worker.Name, worker.QualificationId},
                    commandType: CommandType.StoredProcedure); //тип подключения ??
            }
        }


        public void SetWorkerQualification(WorkersDTO work) //изменить квалификацию мастера  
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                connection.Query(WorkersStoredProcedures.SetWorkerQualification,
                    new { work.Id, work.QualificationId},
                    commandType: CommandType.StoredProcedure);
            }
        }



        public List<WorkersDTO> GetWorkersByServiceId(int Id1) 
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                var parametrs = new
                {
                    Id = Id1
                };
                return connection.Query<WorkersDTO, WorkersServiceDTO, WorkersDTO>(
                    WorkersStoredProcedures.GetWorkersByServiceId,
                    (worker, workerservice) =>
                    {

                        worker.ServiceWork.Add(workerservice);
                        return worker;

                    },
                    parametrs,
                    splitOn: "QualificationName",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }
        }
    }
}
