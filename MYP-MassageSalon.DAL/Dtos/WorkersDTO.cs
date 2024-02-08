using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.DAL.Dtos
{
    public class WorkersDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int QualificationId { get; set; }

        public bool IsDeleted { get; set; }

        public int? WorkIntervalId { get; set; }

        public QualificationDTO QualificationWorker { get; set; }
    }
}
   
