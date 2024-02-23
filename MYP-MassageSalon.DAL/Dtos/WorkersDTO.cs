using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.DAL.Dtos
{
    public class WorkersDTO
    {
        public WorkersDTO()
        {
            ServiceWork = new List<WorkersServiceDTO>();
            WorksApp = new List<WorkerAppointmentsDTO>();
            WorksAppDAte = new List<WorkAppPrDTO>();
            WAD = new List<WorkAppDatePrDTO>();
            WorkIntervals = new List<IntervalWorkPrDTO>();
            QualificationName = new List<QualificationDTO>();
            WorkServ = new List<WorkServDTO>();
        }

        

        public int Id { get; set; }

        public string Name { get; set; }

        public int QualificationId { get; set; }

        public bool IsDeleted { get; set; }

        public int? WorkIntervalId { get; set; }

        public List<QualificationDTO>? QualificationName { get; set; }
        public List<WorkerAppointmentsDTO>? WorksApp { get; set; }

        public List<WorkersServiceDTO>? ServiceWork { get; set; }

        public List<WorkAppPrDTO>? WorksAppDAte { get; set; }
        public List<WorkAppDatePrDTO>? WAD { get; set; }

        public List<IntervalWorkPrDTO>? WorkIntervals { get; set; }

        public List<WorkServDTO>? WorkServ { get; set; }
    }
}
   
