
using MYP_MassageSalon.DAL.IRepositories;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MYP_MassageSalon.DAL.StoredProcedures;
using MYP_MassageSalon.DAL.Dtos;


namespace MYP_MassageSalon.DAL
{
    public class ClientRepository : IClientsRepositories
    {
        public List<ClientsDTO> PPP()
        {
            using (IDbConnection connection = new SqlConnection(Options.ConnectionString))
            {
                return connection.Query<ClientsDto>(ClientsStoredProcedures.PPP).ToList();
            }
        }
    }
}
