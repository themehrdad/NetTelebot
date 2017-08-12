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
    }
}
