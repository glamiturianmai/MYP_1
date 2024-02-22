using AutoMapper;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.DAL.Dtos;
using MYP_MassageSalon.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYP_MassageSalon.BLL.Mapping;

namespace MYP_MassageSalon.BLL;

public class AdminsClient
{
  private ClientRepository _clientRepository = new ClientRepository();
  private Mapper _mapper;

  public AdminsClient()
  {
    _clientRepository = new ClientRepository();

    var config = new MapperConfiguration(cfg => {
      cfg.AddProfile(new AdminMappingProfile()); //пожалуйста возьми вот этот профиль 
    });
    _mapper = new Mapper(config);
  }

  public List<ClientOutputModel> GetAllAdminMap()
  {
    var adminDtos = _clientRepository.GetAllClients();

    var result = _mapper.Map<List<ClientOutputModel>>(adminDtos); //преобразуй список dto в список моделек 

    return result;
  }

}
