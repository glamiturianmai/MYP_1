﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.BLL.Models.OutputModels
{
    public class QualificationWorkersOutputModel
    {
        public int Id { get; set; }
        public string Qualification { get; set; }

        public int ProcentToPrice { get; set; }
    }
}
