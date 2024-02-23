using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.DAL.Dtos
{
    public class ClientAppPrDTO
    {
        public int AppId { get; set; }
        public int IntervalId { get; set; }
        public DateTime Date { get; set;}

        public string WorkerName { get; set; }
        public string ServiceName { get; set; }
        public string UserName { get; set; }
        public decimal Price { get; set; }

        public int Duration { get; set; }

    }
}
