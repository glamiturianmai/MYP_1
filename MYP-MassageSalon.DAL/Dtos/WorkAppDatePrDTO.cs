using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.DAL.Dtos
{
    public class WorkAppDatePrDTO
    {
        
        public DateTime Date { get; set; }

        public string Username { get; set; }
        public int IpInf { get; set; }
        public string ServiceName { get; set; }
    }
}
