﻿using AutoMapper;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.DAL.Dtos;
using MYP_MassageSalon.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYP_MassageSalon.BLL.Mapping;

namespace MYP_MassageSalon.BLL
{
    public class ClientClient
    {
        private ClientRepository _clientRepository;
        private Mapper _mapper;

        public ClientClient()
        {
            _clientRepository = new ClientRepository();

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new ClientMappingProfile()); //пожалуйста возьми вот этот профиль 
            });
            _mapper = new Mapper(config);
        }

        public List<ClientOutputModel> GetAllClientsMap()
        {
            List<ClientsDTO> clientDtos = _clientRepository.GetAllClients();

            var result = _mapper.Map<List<ClientOutputModel>>(clientDtos); //преобразуй список dto в список моделек 

            return result;
        }

    }
}
