using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.DAL.Dtos
{
    public class Service_AppointmentDTO
    {
        public int ServicesId { get; set; }

        public int AppointmentId { get; set; }

        public int WorkerId { get; set; }

        public int Price { get; set; }

        
    }
}
