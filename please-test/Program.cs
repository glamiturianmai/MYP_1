using MYP_MassageSalon.DAL.Dtos;
using MYP_MassageSalon.DAL;
using MYP_MassageSalon.BLL;
using MYP_MassageSalon.BLL.Models.InputModels;
using MYP_MassageSalon.BLL.Models.OutputModels;

//WorkersRepository workRep = new WorkersRepository();
//List<WorkersDTO> a = workRep.GetWorkersByServiceId(2);

WorkerClient workrep = new WorkerClient();
var b = workrep.GetWorkersByServiceIdMap(2);


//ClientRepository workRep = new ClientRepository();
//List<ClientsDTO> a = workRep.GetClientsAppointments(1);

//DeleteAppIntputModel q = new DeleteAppIntputModel();
//q.Id = 1;
//AppointmentClient appClient = new AppointmentClient();
//appClient.DeleteAppointmentMap(q);

//ClientsDTO qq = new ClientsDTO();

//ClientRepository apClient = new ClientRepository();
//var a = apClient.GetClientsAppointments(2);





//AppointmentsOutputModel q = new AppointmentsOutputModel();
//q.Id = 2;
//AppointmentClient appClient = new AppointmentClient();
//var a = appClient.GetClientsAppointmentsMap(2);


Console.ReadLine();