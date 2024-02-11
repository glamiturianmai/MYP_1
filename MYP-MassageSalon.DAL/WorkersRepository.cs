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
                        worker.Appointments = workerappointment;
                        return worker;
                    },
                    parametrs,
                    splitOn: "Id,IntervalId",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }
        }
    }
}
