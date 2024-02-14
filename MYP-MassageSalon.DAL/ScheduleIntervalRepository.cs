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
    }
}
