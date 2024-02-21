using MYP_MassageSalon.DAL.Dtos;
using MYP_MassageSalon.DAL;

ServiceRepository workRep = new ServiceRepository();
List<ServicesDTO> a = workRep.GetAllServicesName();

Console.ReadLine();