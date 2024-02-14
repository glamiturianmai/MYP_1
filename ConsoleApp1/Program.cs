using MYP_MassageSalon.DAL;
using MYP_MassageSalon.DAL.Dtos;
using MYP_MassageSalon.DAL.StoredProcedures;
using System;
using System.Diagnostics;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

////AddAppointment
//AppointmentDTO appdto = new AppointmentDTO()
//{
//    ClientId = 2

//};

//AppointmentnRepository appointRepository = new AppointmentnRepository();

//appointRepository.AddAppointment(appdto);





////AddService_Appointment
//Service_AppointmentDTO servappdto = new Service_AppointmentDTO()
//{
//   ServicesId= 3,
//   AppointmentId = 2,
//   WorkerId= 3,
//   Price =666

//};

//AppointmentnRepository appointRepository1 = new AppointmentnRepository();

//appointRepository1.AddService_Appointment(servappdto);

////AddNewWorker
//WorkersDTO workdto = new WorkersDTO()
//{
//    Name = "ALicetest",
//    QualificationId = 1

//};

//WorkersRepository workRepository = new WorkersRepository();

//workRepository.AddNewWorker(workdto);
















////DeleteAppointment
//AppointmentDTO delappdto = new AppointmentDTO()
//{
//    Id = 10
//};

//AppointmentnRepository appRepository = new AppointmentnRepository();

//appRepository.DeleteAppointment(delappdto);




////DeleteAppointment
//WorkersDTO delworkdto = new WorkersDTO()
//{
//    Id = 4
//};

//WorkersRepository workRepository = new WorkersRepository();

//workRepository.DeleteWorker(delworkdto);

////DeleteService
//ServicesDTO delservdto = new ServicesDTO()
//{
//    Id = 1
//};

//ServiceRepository servRepository = new ServiceRepository();

//servRepository.DeleteService(delservdto);





















////SetService
//ServicesDTO addservdto = new ServicesDTO()
//{
//    Name="прикольный массаж",
//    Cost=897,
//    Time=60
//};

//ServiceRepository servRepository = new ServiceRepository();

//servRepository.SetService(addservdto);




////SetWorkerQualification
//WorkersDTO workqua = new WorkersDTO()
//{
//   Id=6,
//   QualificationId=3,
//};

//WorkersRepository workRepository = new WorkersRepository();

//workRepository.SetWorkerQualification(workqua);
















////GetQualificationWorker
//WorkersDTO qualwork = new WorkersDTO()
//{
//    Id = 2
//};

//WorkersRepository workRepository = new WorkersRepository();

//var a = workRepository.GetQualificationWorker(4);

//foreach (WorkersDTO client in a)
//{
//    Console.WriteLine(client.QualificationWorker.ProcentToPrice);
//}

/////GetAllClients
//ClientRepository clientRepository = new ClientRepository();

//List<ClientsDTO> a = new List<ClientsDTO>();
//a = clientRepository.GetAllClients();


//foreach (ClientsDTO client in a)
//{
//    Console.WriteLine(client.Username);
//}




////GetAllServicesName

//ServiceRepository servRepository = new ServiceRepository();

//var a = servRepository.GetAllServicesName();


//AppointmentnRepository appRepository = new AppointmentnRepository();

//var b = appRepository.GetAllAppointments;
////Console.WriteLine(servRepository[1].Name);




////GetWorkerAppointments
//WorkersRepository workRepository = new WorkersRepository();
DateTime date1 = new DateTime(2024, 02, 14, 10, 54, 00); // год - месяц - день - час - минута - секунда
//var s = workRepository.GetWorkerAppointmentsForDate(2, date1);
IntervalWorkPrDTO addservdto = new IntervalWorkPrDTO()
{
    WorkerId = 4,
    Date = date1,
    

};
WorkersRepository repository = new WorkersRepository();

var w = repository.GetWorkersIntervalsForDate(4, date1);

Console.ReadLine();

//GetAllAppointments



//ServiceRepository servRepository = new ServiceRepository();

//servRepository.SetService(addservdto);





//GetWorkersByServiceId

//WorkersRepository workRepository = new WorkersRepository();

//var a = workRepository.GetWorkersByServiceId(2);

//foreach (WorkersDTO client in a)
//{
//    Console.WriteLine();
//}

//Console.ReadLine();