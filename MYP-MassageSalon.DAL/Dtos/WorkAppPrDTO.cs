using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.DAL.Dtos
{
    public class WorkAppPrDTO
    {
        public int IntervalId { get; set; }
        public DateTime Date { get; set; }

        public string ClientName { get; set; }
        public string ServiceName { get; set; }
    }
}
