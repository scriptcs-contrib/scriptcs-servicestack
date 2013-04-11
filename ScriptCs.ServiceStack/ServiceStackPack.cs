using System;
using System.Reflection;

using Funq;

using ScriptCs.Contracts;

using ServiceStack.WebHost.Endpoints;

namespace ScriptCs.ServiceStack
{
    public class ServiceStackPack : IScriptPackContext
    {
        private const string DefaultServiceName = "ScriptCs ServiceStack Host";

        public void StartHost(string urlBase, string serviceName = DefaultServiceName, Assembly serviceAssembly = null, Action<AppHostHttpListenerBase> configurationBuilder = null)
        {
            if (serviceAssembly == null)
                serviceAssembly = Assembly.GetCallingAssembly();

            var appHost = new ServiceStackAppHost(serviceName, serviceAssembly, configurationBuilder);
            appHost.Init();
            appHost.Start(urlBase);
            
            Console.WriteLine("Listening on {0}...", urlBase);
            Console.WriteLine("Press any key to stop.");
            Console.ReadLine();
        }

        public AppHostHttpListenerBase CreateHost(string serviceName = DefaultServiceName, Assembly serviceAssembly = null, Action<AppHostHttpListenerBase> configurationBuilder = null)
        {
            if (serviceAssembly == null)
                serviceAssembly = Assembly.GetCallingAssembly();

            var appHost = new ServiceStackAppHost(serviceName, serviceAssembly, configurationBuilder);
            appHost.Init();

            return appHost;
        }

        private class ServiceStackAppHost : AppHostHttpListenerBase
        {
            private readonly Action<AppHostHttpListenerBase> _configurationBuilder;

            public ServiceStackAppHost(string serviceName, Assembly serviceAssembly, 
                Action<AppHostHttpListenerBase> configurationBuilder)
                : base(serviceName, serviceAssembly)
            {
                _configurationBuilder = configurationBuilder;
            }

            public override void Configure(Container container)
            {
                if (_configurationBuilder != null) _configurationBuilder.Invoke(this);
            }
        }
    }
}