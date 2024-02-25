using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using MYP_MassageSalon.DAL.Dtos;
using MYP_MassageSalon.DAL.IRepositories;
using MYP_MassageSalon.DAL.StoredProcedures;
using System.Data;
using Dapper;

namespace MYP_MassageSalon.DAL
{
    public class ScheduleIntervalRepository: IScheduleIntervalRepository
    {
        public void SetScheduleInterval(IntervalPrDTO interv) 
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                connection.Query(ScheduleIntervalStoredProcedures.SetScheduleInterval,
                    new { interv.Date, interv.WorkerId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<SheduleIntervalDTO> GetScheduleIntervalsForWorkers(int id1)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                var parametrs = new
                {
                    Id = id1
                };
                return connection.Query<SheduleIntervalDTO>(ScheduleIntervalStoredProcedures.GetScheduleIntervalsForWorkers,
                    parametrs).ToList();
            }
        }

        public void SetAppointmnetInInterval(int intervalId, int appId)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                connection.Query(ScheduleIntervalStoredProcedures.SetAppointmnetInInterval,
                    new { intervalId, appId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<SheduleIntervalDTO> GetIntervalDateById(SheduleIntervalDTO service)
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                return connection.Query<SheduleIntervalDTO>(ScheduleIntervalStoredProcedures.GetIntervalDateById,
                    new { service.Id },
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
