using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.BLL.Models.OutputModels //было
{
    public class ClientAppPrTIMEOutputModel
    {
        public int AppId { get; set; }

        public DateTime Date { get; set; }

        public DateTime TimeStart { get; set; }

        public DateTime TimeEnd { get; set; }

        public string WorkerName { get; set; }

        public string ServiceName { get; set; }

        public decimal Price { get; set; }

    }
}
