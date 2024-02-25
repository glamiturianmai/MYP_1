using MYP_MassageSalon.BLL;
using MYP_MassageSalon.BLL.Models.InputModels;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.DAL;
using MYP_MassageSalon.DAL.Dtos;
using static System.Runtime.InteropServices.JavaScript.JSType;

WorkersDTO dto = new WorkersDTO();
AppointmentnRepository r = new AppointmentnRepository();

var a = r.GetAllAppointments();

AppointmentClient q = new AppointmentClient();

List<WorkersAppOutputModel> m = new List<WorkersAppOutputModel>();

m = q.GetAllAppointmentsAdminMap();

//DateTime date1 = new DateTime(2024, 2, 23, 19, 45, 00);
//dto.ServicePrice=1234;
//dto.WorkerId = 6;
//dto.ClientId = 4;
//dto.ServiceId = 5;
//var a = r.SetAppointment(dto);

//AppointmentDTO dto = new AppointmentDTO();
//dto.ClientId = 6;
//var a = r.AddAppointment(dto);




//AppointmentClient q = new AppointmentClient();
//AddAppClientIntputModel dto = new AddAppClientIntputModel();
//AddAppIntputModel m = new AddAppIntputModel();
//dto.ClientId = 3;

////q.AddAppointmentMap(dto);
//m.WorkerId = 5;
//m.Price = 666;
//m.AppointmentId = 11;
//m.ServicesId = 8;

//q.AddService_AppointmentMap(m);

List<WorkersDTO> workDtos = new WorkersRepository().GetWorkersByServiceId(3);
List<WorkersOutputModel> l = new WorkerClient().GetWorkersByServiceIdMap(3);

Console.ReadLine();