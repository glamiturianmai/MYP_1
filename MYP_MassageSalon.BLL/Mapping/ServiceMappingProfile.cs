﻿using AutoMapper;
using MYP_MassageSalon.BLL.Models.InputModels;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.BLL.Mapping
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<ServicesDTO, ServiceOutputModel>();  
            CreateMap<Services_TypeDTO, ServiceTypeOutputModel>();
            CreateMap<ServiceIntputModel, ServicesDTO>();
            CreateMap<ServicesDTO, ServiceAdminOutputModel>();
            CreateMap<DeleteServiceInputModel, ServicesDTO>();

            CreateMap<ServicesDTO, ServiceNameOutputModel>();
            CreateMap<ServiceIdInputModel, ServicesDTO>();

        }
    }
}
