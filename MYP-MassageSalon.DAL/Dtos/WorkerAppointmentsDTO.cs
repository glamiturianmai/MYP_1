using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.DAL.Dtos
{
    public class WorkerAppointmentsDTO 
    {
        public SheduleIntervalDTO? Interval{ get; set; } //IntervalId

        public List<ClientsDTO> Clients { get; set; } //ClientName

        public List<ServicesDTO> Services { get; set; } //ServiceName
    }
}
