using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.DAL.StoredProcedures
{
    public class ScheduleIntervalStoredProcedures
    {
        public const string SetScheduleInterval = "SetScheduleInterval";

        public const string GetScheduleIntervalsForWorkers = "GetScheduleIntervalsForWorkers";

        public const string SetAppointmnetInInterval = "SetAppointmnetInInterval";

        public const string GetIntervalDateById = "GetIntervalDateById";
    }
}
