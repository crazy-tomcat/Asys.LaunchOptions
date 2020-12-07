using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Asys.LaunchOptions
{
    public class Options<TParameters>
        where TParameters : new()
    {
        public Options(string[] args)
        {
            var parameters = typeof(TParameters).GetProperties();
            foreach (var propertyInfo in parameters)
            {
                var pa = propertyInfo.GetCustomAttributes<LaunchParameterAttribute>().FirstOrDefault();
                if (pa != null)
                {
                    _dictionaryParameters.Add(propertyInfo.Name.ToLower(), new LaunchProperty(pa, propertyInfo));
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

            var c = args[0][0];
            var start = 0;
            if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
            {
                // проверка того что первый символ является буквенным
                Command = args[0];
                start = 1;
            }

            Parameters = new TParameters();

            for (var i = start; i < args.Length; i++)
            {
                var l = args[i];
                if (l[0] == '/')
                {
                    // параметр имя=значение
                    var pv = l.Split('=');
                    var pName = pv[0].Substring(1).ToLower();
                    _dictionaryParameters[pName].Property.SetValue(Parameters, pv[1]);
                }
                else if (l[0] == '-')
                {
                    // переключатель да/нет
                    _dictionaryParameters[l.Substring(1).ToLower()].Property.SetValue(Parameters, true);
                }
            }
        }

        public string Command { get; }

        public TParameters Parameters { get; }

        private Dictionary<string, LaunchProperty> _dictionaryParameters = new Dictionary<string, LaunchProperty>();

        private Dictionary<string, LaunchProperty> _dictionarySwitches = new Dictionary<string, LaunchProperty>();
    }
}
