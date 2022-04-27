using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace HostApp
{
    class Program
    {
        private static Dictionary<string, IPlugin> Plugins = new Dictionary<string, IPlugin>();
        static AssemblyName SelfName()
        {
            return typeof(Program).Assembly.GetName();
        }
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
                    if (File.Exists(p))
                    {
                        var a = Assembly.LoadFile(p);
                        foreach (Type t in a.GetTypes())
                        {
                            if (typeof(IPlugin).IsAssignableFrom(t))
                            {
                                IPlugin plugin = Activator.CreateInstance(t) as IPlugin;
                                Program.Plugins.Add(plugin.Name, plugin);
                            }
                        }

                    } else {
                        Console.WriteLine($"File not found:\n{p}");
                    }
                }

                var loop = "y";
                var name = "";
                var pluginNames = string.Join(", ", Program.Plugins.Keys);

                while (loop == "y")
                {
                    Console.WriteLine($"Available plugins: {pluginNames}");
                    Console.WriteLine($"Enter plugin name to execute:");

                    while (!Program.Plugins.Keys.Contains(name))
                    {
                        name = Console.ReadLine();
                    }

                    var plug = Program.Plugins[name];

                    var data = new CommandData(){Content = "Hello, World"};

                    var res = plug.Execute(data);

                    name = "";

                    Console.WriteLine($"Plugin result: {res}");
                    Console.WriteLine("Continue? [y | n]");
                    loop = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static Dictionary<string, IPlugin> LoadPlugin(string path)
        {
            return new Dictionary<string, IPlugin>();
        }
    }
}
