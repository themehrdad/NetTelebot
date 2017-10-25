using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mock4Net.Core;

namespace NetTelebot.CommonUtils
{
    public static class ConsoleUtlis
    {
        public static void PrintResult<T>(T result) where T : class  
        {
            foreach (PropertyInfo properties in result.GetType().GetProperties())
            {
                WriteConsoleLog("Property name: " + properties.Name + ". Property value: " + properties.GetValue(result, null));
            }
        }

        public static void PrintResult<T>(T[] result) where T : class
        {
            foreach (PropertyInfo properties in result.GetType().GetProperties())
            {
                WriteConsoleLog("Property name: " + properties.Name + ". Property value: " + properties.GetValue(result, null));
            }
        }

        public static void PrintResult(DateTime result)
        {
            foreach (PropertyInfo properties in result.GetType().GetProperties())
            {
                WriteConsoleLog("Property name: " + properties.Name + ". Property value: " + properties.GetValue(result, null));
            }
        }

        public static void PrintSimpleResult<T>(T result) where T : struct
        {
            var properties = result.GetType().Name;

            WriteConsoleLog("Property name: " + properties + ". Property value: " + result);
        }

        public static void PrintSimpleResult(string result)
        {
            var properties = result.GetType().Name;

            WriteConsoleLog("Property name: " + properties + ". Property value: " + result);
        }

        internal static void PrintResult(IEnumerable<Request> request)
        {
            WriteConsoleLog(request.FirstOrDefault()?.Body);
            WriteConsoleLog(request.FirstOrDefault()?.Url);
        }

        public static void WriteConsoleLog(string text)
        {
            Console.WriteLine(DateTime.Now.ToLocalTime() + " " + text);
        }
    }
}
