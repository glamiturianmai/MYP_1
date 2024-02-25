using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.BLL.Models.OutputModels
{
    public class WorkerAppointmentsOutputModel
    {
        public DateTime Date { get; set; }

        public string Username { get; set; } //клиента

        public int IpInf { get; set; }
        public string ServiceName { get; set; }
    }
}
