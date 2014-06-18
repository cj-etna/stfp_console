using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Collections.Specialized;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome, " + ConfigurationManager.AppSettings.Get("user") + ".");
            Console.WriteLine("Get or Set data?");
            var cmd = Console.ReadLine();
            
            if (Validate.GetOrSet(cmd) == Validate.Result.Get)
            {
                Console.WriteLine("Enter a key index to get var");
                var index = Console.ReadLine();

                string result = ConfigurationManager.AppSettings.Get(index);
                if (!String.IsNullOrEmpty(result))
                {
                    string value = ConfigurationManager.AppSettings.Get(index);
                    Console.WriteLine("key " + index + " = " + value);
                }
                else
                {
                    Console.WriteLine("That key/value pair doesn't exist");
                }
                
            }
            else if (Validate.GetOrSet(cmd) == Validate.Result.Set)
            {
                Console.WriteLine("Enter a key index");
                var index = Console.ReadLine();
                Console.WriteLine("Enter a value for key " + index);
                var value = Console.ReadLine();

                ConfigurationManager.AppSettings.Add(index, value);
            }
            else if (Validate.GetOrSet(cmd) == Validate.Result.None)
            {
                Console.WriteLine("Piss off");
            }
            else
                throw new Exception();

            var end = Console.ReadLine();
            
        }

        static protected class Validate
        {
            public enum Result{None, Get, Set}
            static public Result GetOrSet(string arg)
            {
                if (arg == "get" || arg == "Get")
                    return Result.Get;
                else if (arg == "set" || arg == "Set")
                    return Result.Set;
                else
                    return Result.None;
            }
        }
    }
}
