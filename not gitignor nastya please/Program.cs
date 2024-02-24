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





ServiceClient q = new ServiceClient();
ServiceIntputModel dto = new ServiceIntputModel();
//m.Name = "aaa";
//m.QualificationId = 1;
//q.AddNewWorkerMap(m);
dto.Name = "лимфодренажный массаж";
dto.Price = 3800;
dto.Time = 60;
q.SetServiceMap(dto);

Console.ReadLine();