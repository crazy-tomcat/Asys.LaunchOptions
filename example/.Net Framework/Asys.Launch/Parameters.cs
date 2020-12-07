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
        [LaunchParameter]
        public string InputFolder { get; set; }

        [LaunchParameter]
        public string OutputFolder { get; set; }

        [LaunchSwitch]
        public bool AutoDelete { get; set; }
    }
}
