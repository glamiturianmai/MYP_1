using MYP_MassageSalon.DAL.Dtos;
using MYP_MassageSalon.DAL;

WorkersRepository workRep = new WorkersRepository();
var a = workRep.GetWorkersByServiceId(2);

Console.ReadLine();