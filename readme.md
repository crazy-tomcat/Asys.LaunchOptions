[![NuGet version](https://badge.fury.io/nu/Asys.LaunchOptions.png)](https://badge.fury.io/nu/Asys.LaunchOptions)

Example

Create class for options:
```
    public class Parameters
    {
        [LaunchParameter(Description = "input folder", IsRequired = true)]
        public string InputFolder { get; set; }

        [LaunchParameter(Description = "output folder", IsRequired = true)]
        public string OutputFolder { get; set; }

        [LaunchSwitch(Description = "auto delete files")]
        public bool AutoDelete { get; set; }
    }
```

Use in Program
```
    class Program
    {
        static void Main(string[] args)
        {
            var o = new Options<Parameters>(args);

            var inputFolder = o.Parameters.InputFolder;
            var outputFolderf = o.Parameters.OutputFolder;
        }
    }
```

Start with parameter
```
Program.exe /inputfolder="c:\inputFolder" /outputfolder="c:\outputFolder"
```
