using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MYP_MassageSalon.DAL.Dtos
{
    public class SheduleIntervalDTO
    {
        public int? Id { get; set; }

        public DateTime Date { get; set; }

        public int? WorkerId { get; set; }

        public int? AppointmentId { get; set; }

        public bool? IsBusy { get; set; }

        public int? WorkIntervalId { get; set; }
    }
   
}
