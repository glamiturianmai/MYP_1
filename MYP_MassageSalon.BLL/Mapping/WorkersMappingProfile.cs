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
    public class WorkersMappingProfile : Profile
    {
        public WorkersMappingProfile()
        {
            //CreateMap<WorkersDTO, WorkersAdminOutputModel>();
            CreateMap<WorkersDTO, WorkersOutputModel>();

            CreateMap<WorkersDTO, WorkersAllOutputModel>();
            CreateMap<QualificationDTO, QualificationWorkersOutputModel>();
            CreateMap<TypeDTO, TypeOutputModel>();


            CreateMap<WorkServDTO, WorkServOutputModel>();

            CreateMap<SheduleIntervalDTO, IntervalsOutputModel>();
            CreateMap<DeleteWorkerInputModel, WorkersDTO>();
            CreateMap<QualifWorkerInputModels, WorkersDTO>();
            CreateMap<QualificationDTO, QualificationsOutputModel>();
            CreateMap<WorkersAddInputModel, WorkersDTO>();

            CreateMap<IntervalIntputModel, IntervalPrDTO>();
            CreateMap<WorkersDTO, WorkersModel>();

            CreateMap<WorkerIdInputModel, WorkersDTO>();
            CreateMap<WorkersDTO, WorkerINameOutputModel>();

            CreateMap<WorkerAppointmentsDTO, WorkerAppointmentsOutputModel>();
            CreateMap<WorkersDTO, WorkersAppOutputModel>();


            CreateMap<WorkersDTO, AppointmentsAdminOutputModel>();
        }
    }
}
