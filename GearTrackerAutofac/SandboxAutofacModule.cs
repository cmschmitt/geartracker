using Autofac;
using System;
using System.Reflection;

namespace SandboxAutofac
{
    public class SandboxAutofacModule : Autofac.Module
    {
        private string _dataSource;
        private Assembly _executingAssembly;

        public SandboxAutofacModule(string dataSource, Assembly executingAssembly)
        {
            _dataSource = dataSource;
            _executingAssembly = executingAssembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var connectionString = $"Data source = {_dataSource};Initial Catalog = GearTracker;Integrated Security = True;MultipleActiveResultSets=True;";
            builder.RegisterAssemblyTypes(_executingAssembly).Where(t => typeof(BaseViewModel).IsAssignableFrom(t));
            builder.RegisterType<PageService>()
        }
    }
}
