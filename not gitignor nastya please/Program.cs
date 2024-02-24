using MYP_MassageSalon.BLL;
using MYP_MassageSalon.BLL.Models.InputModels;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.DAL;
using MYP_MassageSalon.DAL.Dtos;
using static System.Runtime.InteropServices.JavaScript.JSType;

IntervalIntputModel dto = new IntervalIntputModel();
WorkerClient r = new WorkerClient();

 DateTime date1 = new DateTime(2024, 2, 23, 18, 15, 00);
dto.Date = date1;
dto.WorkerId = 5;
r.SetScheduleIntervalMap(dto);





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

Console.ReadLine();