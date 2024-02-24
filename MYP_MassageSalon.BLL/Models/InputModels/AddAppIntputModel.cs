using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.BLL.Models.InputModels
{
    public class AddAppIntputModel
    {
        public int ServicesId { get; set;}
        public int AppointmentId { get; set; }
        public int WorkerId { get; set; }
        public int Price { get; set; }

    }
}
