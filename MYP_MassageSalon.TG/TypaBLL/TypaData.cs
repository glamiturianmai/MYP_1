using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.TG.TypaBLL
{
    internal class TypaData
    {
        public Dictionary<int, string> GetAllServices()
        {
            return new Dictionary<int, string>
            {
                {1, "Pervaya"},
                {2, "Vtoraya"},
                {3, "Tretya"}
            };

        }

        Dictionary<long, string> Clients = new Dictionary<long, string>
            {
                {1, "Vanya"},
                {2, "Petya"},
                {3, "Katya"}
            };

        public Dictionary<long, string> GetAllClients() //мой чат айди 415367116
        {
            return Clients;
        }

        public void AddClient(long id, string name)
        {
            Clients.Add(id, name);
        }
    }
}
