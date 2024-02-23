using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.DAL.StoredProcedures
{
    public class WorkersStoredProcedures
    {
        public const string GetQualificationWorker = "GetQualificationWorker";

        public const string GetWorkerAppointments = "GetWorkerAppointments";
        public const string GetWorkerAppointmentsForDate = "GetWorkerAppointmentsForDate";
        public const string DeleteWorker = "DeleteWorker";
        public const string AddNewWorker = "AddNewWorker";
        public const string SetWorkerQualification = "SetWorkerQualification";
        public const string GetWorkersByServiceId = "GetWorkersByServiceId";
        public const string GetWorkersIntervalsForDate = "GetWorkersIntervalsForDate";
        public const string GetALLQualificationWorkers = "GetALLQualificationWorkers";
        public const string GetAllWorker = "GetAllWorkers";
    }
}

