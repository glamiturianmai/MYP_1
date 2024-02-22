using MYP_MassageSalon.DAL.Dtos;
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
        public List<ClientAppPrOutputModel>? WorksApp { get; set; }
    }
}
