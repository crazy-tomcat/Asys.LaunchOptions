using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Asys.LaunchOptions
{
	public class Options<TParameters>
		where TParameters : new()
	{
		public Options(string[] args, bool interactiveQuery = false)
		{
			var parameters = typeof(TParameters).GetProperties();
			var requiredParameters = new List<LaunchProperty>();

			foreach (var propertyInfo in parameters)
			{
				var pa = propertyInfo.GetCustomAttributes<LaunchParameterAttribute>().FirstOrDefault();
				if (pa != null)
				{
					var lp = new LaunchProperty(pa, propertyInfo);
					_dictionaryParameters.Add(propertyInfo.Name.ToLower(), lp);
					if (pa.IsRequired)
					{
						requiredParameters.Add(lp);
					}
				}
				else
				{
					var sa = propertyInfo.GetCustomAttributes<LaunchSwitchAttribute>().FirstOrDefault();
					if (sa != null)
					{
						_dictionarySwitches.Add(propertyInfo.Name.ToLower(), new LaunchProperty(sa, propertyInfo));
					}
				}
			}

			if (args == null || args.Length == 0 && !interactiveQuery)
			{
				ShowHelp();
				return;
			}

			Parameters = new TParameters();
			if (args != null && args.Length > 0)
			{
				var c = args[0][0];
				var start = 0;
				if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
				{
					// проверка того что первый символ является буквенным
					Command = args[0];
					start = 1;
				}

				if (Command == "help")
				{
					ShowHelp();
					return;
				}


				for (var i = start; i < args.Length; i++)
				{
					var l = args[i];
					if (l[0] == '/')
					{
						// параметр имя=значение
						var pv = l.Split('=');
						var pName = pv[0].Substring(1).ToLower();
						if (!_dictionaryParameters.TryGetValue(pName, out var lProp))
						{
							lProp.Value = pv[1];
							lProp.Property.SetValue(Parameters, lProp.Value);
						}
					}
					else if (l[0] == '-')
					{
						// переключатель да/нет
						_dictionarySwitches[l.Substring(1).ToLower()].Property.SetValue(Parameters, true);
					}
				}
			}

			if (interactiveQuery && requiredParameters.Count > 0)
			{
				Console.WriteLine("Please enter required parameters...");
				foreach (var requiredParameter in requiredParameters)
				{
					Console.Write(requiredParameter.Attribute.Description + ": ");
					var str = Console.ReadLine();
					requiredParameter.Value = str;
					requiredParameter.Property.SetValue(Parameters, requiredParameter.Value);
				}
			}
		}

		public string Command { get; }

		public TParameters Parameters { get; }

		private void ShowHelp()
		{
			Console.WriteLine("Usage:");
			Console.WriteLine($"{Path.GetFileName(Assembly.GetEntryAssembly().Location)} /paramName=paramValue [-option1 [-option2]]");
			Console.WriteLine("Options:");
			foreach (var option in _dictionaryParameters)
			{
				Console.WriteLine($"  /{option.Key}  {option.Value.Attribute.Description}");
			}

			Console.WriteLine("Switches:");
			foreach (var @switch in _dictionarySwitches)
			{
				Console.WriteLine($"  -{@switch.Key}  {@switch.Value.Attribute.Description}");
			}
		}

		private readonly Dictionary<string, LaunchProperty> _dictionaryParameters = new Dictionary<string, LaunchProperty>();

		private readonly Dictionary<string, LaunchProperty> _dictionarySwitches = new Dictionary<string, LaunchProperty>();
	}
}