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
DeleteServiceInputModel dto = new DeleteServiceInputModel();
dto.Id = 10;
q.DeleteServiceMap(dto);


Console.ReadLine();