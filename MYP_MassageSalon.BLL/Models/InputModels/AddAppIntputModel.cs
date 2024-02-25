using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.BLL.Models.InputModels
{
    public class AddAppIntputModel
    {
        public int? ClientId { get; set; }
        public int ServiceId { get; set;}
        public int AppId { get; set; }
        public int WorkerId { get; set; }
        public decimal ServicePrice { get; set; }

    }
}
