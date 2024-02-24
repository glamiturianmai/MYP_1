using MYP_MassageSalon.BLL;
using MYP_MassageSalon.BLL.Models.InputModels;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.DAL;
using MYP_MassageSalon.DAL.Dtos;

//ServicesDTO dto = new ServicesDTO();
//ServiceRepository r = new ServiceRepository();
//dto.Name = "скульптурирующий массаж";
//dto.Price = 4200;
//dto.Time = 75;
//r.SetService(dto);





AppointmentClient q = new AppointmentClient();
AddAppClientIntputModel dto = new AddAppClientIntputModel();
AddAppIntputModel m = new AddAppIntputModel();
dto.ClientId = 3;

//q.AddAppointmentMap(dto);
m.WorkerId = 5;
m.Price = 666;
m.AppointmentId = 11;
m.ServicesId = 8;

q.AddService_AppointmentMap(m);

//Console.ReadLine();