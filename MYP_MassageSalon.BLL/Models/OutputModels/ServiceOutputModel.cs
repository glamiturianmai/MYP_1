using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.BLL.Models.OutputModels
{
    public class ServiceOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int Time { get; set; }


        public ServiceTypeOutputModel ServiceType { get; set; } //ссылка на модель в моделе
    }
}
