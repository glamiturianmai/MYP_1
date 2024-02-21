using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MYP_MassageSalon.BLL.Models.OutputModels
{
    public class AppointmentsAdminOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; } 

        public DateTime Date { get; set; } 
        public ClientOutputModel Username { get; set; }
        public ServiceOutputModel ServiceName { get; set; } 
    }
}
