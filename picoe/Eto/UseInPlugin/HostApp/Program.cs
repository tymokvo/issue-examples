using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HostApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cwd = Directory.GetCurrentDirectory();
            try
            {
                var pluginPaths = File
                    .ReadAllLines("pluginpaths.txt")
                    .Select((p) => Path.Combine(cwd, p));

                foreach (string p in pluginPaths)
                {
                    Console.WriteLine($"Loading plugin: {p}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
