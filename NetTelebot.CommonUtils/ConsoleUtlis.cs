using System;
using System.Reflection;

namespace NetTelebot.CommonUtils
{
    public static class ConsoleUtlis
    {
        public static void PrintResult<T>(T result) where T : class  
        {
            foreach (PropertyInfo properties in result.GetType().GetProperties())
            {
                Console.WriteLine("Property name: " + properties.Name + ". Property value: " + properties.GetValue(result, null));
            }
        }

        public static void PrintResult<T>(T[] result) where T : class
        {
            foreach (PropertyInfo properties in result.GetType().GetProperties())
            {
                Console.WriteLine("Property name: " + properties.Name + ". Property value: " + properties.GetValue(result, null));
            }
        }

        public static void PrintResult(DateTime result)
        {
            foreach (PropertyInfo properties in result.GetType().GetProperties())
            {
                Console.WriteLine("Property name: " + properties.Name + ". Property value: " + properties.GetValue(result, null));
            }
        }

        public static void PrintSimpleResult<T>(T result) where T : struct
        {
            var properties = result.GetType().Name;

            Console.WriteLine("Property name: " + properties + ". Property value: " + result);
        }

        public static void PrintSimpleResult(string result)
        {
            var properties = result.GetType().Name;

            Console.WriteLine("Property name: " + properties + ". Property value: " + result);
        }

        public static void WriteConsoleLog(string text)
        {
            Console.WriteLine(DateTime.Now.ToLocalTime() + " " + text);
        }
    }
}
