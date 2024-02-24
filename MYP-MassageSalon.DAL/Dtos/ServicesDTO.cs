using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.DAL.Dtos
{
    public class ServicesDTO
    {
        public ServicesDTO()
        {
            ServType = new List<ServTypePrDTO>();
        }
        public int? Id { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }


        public int? Time { get; set; }

        

        public bool? IsDeleted { get; set; }

        public Services_TypeDTO? ServiceType { get; set; }

        public List<ServTypePrDTO>? ServType { get; set; }

    }
}
