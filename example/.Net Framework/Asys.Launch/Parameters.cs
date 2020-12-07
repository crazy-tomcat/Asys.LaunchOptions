using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using Asys.LaunchOptions;

namespace Asys.Launch
{
    public class Parameters
    {
        [LaunchParameter(Description = "input folder", IsRequired = true)]
        public string InputFolder { get; set; }

        [LaunchParameter(Description = "output folder", IsRequired = true)]
        public string OutputFolder { get; set; }

        [LaunchSwitch(Description = "auto delete files")]
        public bool AutoDelete { get; set; }
    }
}
