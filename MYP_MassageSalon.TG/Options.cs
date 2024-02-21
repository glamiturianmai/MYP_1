using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYP_MassageSalon.TG
{
    public class Options
    {
        public static string ConStrTG
        {
            get
            {
                return Environment.GetEnvironmentVariable("TG_Bot_MYP");
            }
        }
    }
}
