using System;
using System.Reflection;
using System.Runtime.Loader;

namespace HostApp
{
    class PluginLoadContext : AssemblyLoadContext
    {
        protected override Assembly Load(AssemblyName assemblyName)
        {
            throw new NotImplementedException();
        }
    }
}
