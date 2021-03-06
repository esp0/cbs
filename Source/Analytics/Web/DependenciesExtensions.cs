using Microsoft.Extensions.DependencyInjection;
using Web.Controllers;
using Read.CaseReports;
using Read;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Read.KPI;
using Read.HealthRisks;
using Read.DataCollectors;

namespace Web
{
    public static class DependenciesExtensions
    {
        public static AutofacServiceProvider RegisterDependencies(this IServiceCollection services)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<EpicurveService>();
            containerBuilder.RegisterType<MongoDBHandler>();
            containerBuilder.RegisterType<KPIRepository>();
            containerBuilder.RegisterType<CaseReportRepository>();
            containerBuilder.RegisterType<HealthRisksEventHandler>().As<IHealthRisksEventHandler>();
            containerBuilder.RegisterType<CaseReportsEventHandler>().As<ICaseReportsEventHandler>();
            containerBuilder.RegisterType<DataCollectorEventHandler>().As<IDataCollectorsEventHandler>();
            containerBuilder.Populate(services);

            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }
    }
}
