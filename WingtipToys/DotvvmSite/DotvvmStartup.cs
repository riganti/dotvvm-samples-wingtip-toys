using DotVVM.Framework.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WingtipToys.DotvvmSite
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            ConfigureRoutes(config, applicationPath);
            ConfigureResources(config, applicationPath);
            ConfigureControls(config, applicationPath);
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            // configure your DotVVM routes here
            config.RouteTable.Add("Test", "test", "DotvvmSite/Views/Test.dothtml");
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {

        }

        public void ConfigureServices(IDotvvmServiceCollection options)
        {
            
        }
    }
}