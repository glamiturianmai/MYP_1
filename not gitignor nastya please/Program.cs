using MYP_MassageSalon.BLL;
using MYP_MassageSalon.BLL.Models.InputModels;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.DAL;
using MYP_MassageSalon.DAL.Dtos;

//QualificationDTO workersDTO = new QualificationDTO();
//WorkersRepository r = new WorkersRepository();

//var b = r.GetQualifWorker();





WorkerClient q = new WorkerClient();
WorkersAddInputModel m =  new WorkersAddInputModel();
m.Name = "aaa";
m.QualificationId = 1;
q.AddNewWorkerMap(m);


Console.ReadLine();