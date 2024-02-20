using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.BLL.Models.OutputModels
{
    public class AppointmentsOutputModel
    { 
        public string Name { get; set; } //имя мастера

        public DateTime Date { get; set; } //дата (удивительно)
       
        public string SeviceName { get; set; } //название услуги 
    }
}
