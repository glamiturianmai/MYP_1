﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.BLL.Models.OutputModels
{
    public class WorkersOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<WorkServOutputModel> WorkServ { get; set; }
    }
}
