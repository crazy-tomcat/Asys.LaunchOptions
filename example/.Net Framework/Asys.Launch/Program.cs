using Asys.LaunchOptions;

namespace Asys.Launch
{
	class Program
	{
		static void Main(string[] args)
		{
			var o = new Options<Parameters>(args, true);

			if (o.Parameters != null)
			{
				var inputFolder = o.Parameters.InputFolder;
				var outputFolder = o.Parameters.OutputFolder;
			}
		}
	}
}
