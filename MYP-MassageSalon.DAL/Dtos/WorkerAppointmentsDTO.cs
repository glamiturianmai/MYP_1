using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.DAL.Dtos
{
    public class WorkerAppointmentsDTO 
    {
        public DateTime Date { get; set; } 

        public string Username { get; set; } //клиента

        public int IpInf { get; set; } 
        public string ServiceName { get; set; }

        //public ServicesDTO? ServiceName { get; set; }

        //public ClientsDTO? Username { get; set; }

        public int? AppId { get; set; }
    }
}
