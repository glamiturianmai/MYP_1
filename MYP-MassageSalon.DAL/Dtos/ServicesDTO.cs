using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.DAL.Dtos
{
    public class ServicesDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Cost { get; set; }


        public DateTime Time { get; set; }

        

        public bool? IsDeleted { get; set; }

        public Services_TypeDTO? ServiceType { get; set; }



    }
}
