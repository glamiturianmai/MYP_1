using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.BLL.Models.InputModels
{
    public class Service_AppointmentIntputModel
    {
        public int? ApppId { get; set; }
        public int ServiceId { get; set; }

        public int WorkerId { get; set; }
        public decimal Price { get; set; }
    }
}
