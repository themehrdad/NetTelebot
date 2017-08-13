using System;

namespace NetTelebot.CommonUtils
{
    public static class ConsoleUtlis
    {
        public static void PrintResult<T>(T result) where T : class
        {
            foreach (var properties in result.GetType().GetProperties())
            {
                Console.WriteLine("Property name: " + properties.Name + ". Property value: " + properties.GetValue(result, null));
            }

        }

        public static void PrintResult(DateTime result)
        {
            foreach (var properties in result.GetType().GetProperties())
            {
                Console.WriteLine("Property name: " + properties.Name + ". Property value: " + properties.GetValue(result, null));
            }

        }

        public static void PrintResult(long result)
        {
            var properties = result.GetType().Name;

            Console.WriteLine("Property name: " + properties + ". Property value: " + result);
        }

        public static void PrintResult(int result)
        {
            var properties = result.GetType().Name;

            Console.WriteLine("Property name: " + properties + ". Property value: " + result);
        }

        public static void PrintResult(bool result)
        {
            var properties = result.GetType().Name;

            Console.WriteLine("Property name: " + properties + ". Property value: " + result);
        }

        public static void PrintResult(string result)
        {
            var properties = result.GetType().Name;

            Console.WriteLine("Property name: " + properties + ". Property value: " + result);
        }
    }
}
