using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.DAL.Dtos
{
    public class ClientsDTO
    {
        public ClientsDTO()
        {
            ClientApp = new List<ClientAppPrDTO>();
        }
        public int Id { get; set; }

        public string Username { get; set; }

        public int? IPInf { get; set; }

        public bool IsDeleted { get; set; }

        public List<ClientAppPrDTO>? ClientApp { get; set; }
    }
}
