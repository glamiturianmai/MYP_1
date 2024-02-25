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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MYP_MassageSalon.DAL
{
    public class WorkersRepository : IWorkersRepository
    {
        public List<WorkersDTO> GetQualificationWorker(int Id1) //квалификация по id мастера - 2 таблички  
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                var parametrs = new
                {
                    WorkerId = Id1
                };
                return connection.Query<WorkersDTO, QualificationDTO, WorkersDTO>(
                    WorkersStoredProcedures.GetQualificationWorker,
                    (worker, qualification) =>
                    {
                        worker.QualificationName.Add(qualification);
                        return worker;
                    },
                    parametrs,
                    splitOn: "QualificationId",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public List<WorkersDTO> GetAllWorker()   
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                return connection.Query<WorkersDTO, QualificationDTO, WorkersDTO>(
                    WorkersStoredProcedures.GetAllWorker,
                    (worker, qualification) =>
                    {
                        worker.QualificationName.Add(qualification);
                        return worker;
                    },
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
                    Id = Id1
                };
                return connection.Query<WorkersDTO, WorkAppPrDTO, WorkersDTO>(
                    WorkersStoredProcedures.GetWorkerAppointments,
                    (worker, workapp) =>
                    {
                        worker.WorksAppDAte.Add(workapp);
                        return worker;
                    },
                    parametrs,
                    splitOn: "IntervalId",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }
        }


        public List<WorkersDTO> GetWorkerAppointmentsForDate(int Id1, DateTime Date1) //заявки id мастера - много табличек   
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                var parametrs = new
                {
                    Id = Id1,
                    Date = Date1
                };
                return connection.Query<WorkersDTO, WorkAppDatePrDTO, WorkersDTO>(
                    WorkersStoredProcedures.GetWorkerAppointmentsForDate,
                    (worker, workapp) =>
                    {
                        worker.WAD.Add(workapp);
                        return worker;
                    },
                    parametrs,
                    splitOn: "Date",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public List<WorkersDTO> GetWorkersIntervalsForDate(int Id1, DateTime Date1) //заявки id мастера - много табличек   
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                var parametrs = new
                {
                    WorkerId = Id1,
                    Date = Date1
                };
                return connection.Query<WorkersDTO, IntervalWorkPrDTO, WorkersDTO>(
                    WorkersStoredProcedures.GetWorkersIntervalsForDate,
                    (worker, workinterv) =>
                    {
                        worker.WorkIntervals.Add(workinterv);
                        return worker;
                    },
                    parametrs,
                    splitOn: "IntervalId",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
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
                return connection.Query<WorkersDTO, WorkServDTO, WorkersDTO>(
                    WorkersStoredProcedures.GetWorkersByServiceId,
                    (worker, qual) =>
                    {

                        worker.WorkServ.Add(qual);
                        return worker;

                    },
                    parametrs,
                    splitOn: "QualificationName",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }
        }


        public List<WorkersDTO> GetALLQualificationWorkers(int Id1)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {

                return connection.Query<WorkersDTO, WorkersServiceDTO, WorkersDTO>(
                    WorkersStoredProcedures.GetALLQualificationWorkers,
                    (worker, workerservice) =>
                    {

                        worker.ServiceWork.Add(workerservice);
                        return worker;

                    },

                    splitOn: "QualificationName",
                    commandType: CommandType.StoredProcedure
                    ).ToList();

            }
        }

        public void DeleteWorker(WorkersDTO service) 
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                connection.Query(WorkersStoredProcedures.DeleteWorker,
                    new { service.Id },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void SetQualificationWorker(WorkersDTO service)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                connection.Query(WorkersStoredProcedures.SetQualificationWorker,
                    new { service.Id, service.QualificationId},
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<QualificationDTO> GetQualifWorker()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                return connection.Query<QualificationDTO>(WorkersStoredProcedures.GetQualifWorker).ToList();
            }
        }

        public void AddNewWorker(WorkersDTO client)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                connection.Query(WorkersStoredProcedures.AddNewWorker,
                    new { client.Name, client.QualificationId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<WorkersDTO> GetWorkerNameById(WorkersDTO service)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                return connection.Query<WorkersDTO>(WorkersStoredProcedures.GetWorkerNameById,
                    new { service.Id },
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
