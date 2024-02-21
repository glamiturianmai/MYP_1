using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.BLL.Models.OutputModels
{
    public class AppointmentsOutputModel
    {
        public int Id { get; set; } 
        public string Name { get; set; } //имя мастера

        public DateTime Date { get; set; } //дата (удивительно)
       
        public string ServiceName { get; set; } //название услуги 
    }
}
