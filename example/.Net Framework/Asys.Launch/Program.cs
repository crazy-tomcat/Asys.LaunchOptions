using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asys.LaunchOptions;

namespace Asys.Launch
{
    class Program
    {
        static void Main(string[] args)
        {
            var o = new Options<Parameters>(args);

            var inputFolder = o.Parameters.InputFolder;
            var outputFolderf = o.Parameters.OutputFolder;
        }
    }
}
