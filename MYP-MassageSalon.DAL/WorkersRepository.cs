using Dapper;
using Microsoft.Data.SqlClient;
using MYP_MassageSalon.DAL.Dtos;
using MYP_MassageSalon.DAL.IRepositories;
using MYP_MassageSalon.DAL.StoredProcedures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.DAL
{
    public class WorkersRepository: IWorkersRepository
    {
        public List<WorkersDTO> GetQualificationWorker(WorkersDTO workers) //квалификация по id мастера - 2 таблички  
        {
            using (IDbConnection connection = new SqlConnection(Options.ConStr))
            {
                return connection.Query<WorkersDTO, QualificationDTO, WorkersDTO>(
                    WorkersStoredProcedures.GetQualificationWorker,
                    (worker, qualification) =>
                    {
                        worker.QualificationWorker = qualification;
                        return worker;
                    },
                    new { workers.Id },
                    splitOn: "id",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }
        }
    }
}
