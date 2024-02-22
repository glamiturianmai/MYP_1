using MYP_MassageSalon.DAL.Dtos;
using MYP_MassageSalon.DAL;
using MYP_MassageSalon.BLL;

//WorkersRepository workRep = new WorkersRepository();
//List<WorkersDTO> a = workRep.GetWorkersByServiceId(2);

WorkerClient workrep = new WorkerClient();
var b = workrep.GetWorkersByServiceIdMap(2);


ClientRepository workRep = new ClientRepository();
List<ClientsDTO> a = workRep.GetClientsAppointments(1);

AppointmentClient appClient = new AppointmentClient();
var d = appClient.GetClientsAppointmentsMap(1);

Console.ReadLine();