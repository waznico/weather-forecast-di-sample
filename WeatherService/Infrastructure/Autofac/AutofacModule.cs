using Autofac;
using WeatherService.Services;

namespace WeatherService.Infrastructure.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqliteWeatherValuesService>()
                .As<IWeatherValuesService>()
                .InstancePerLifetimeScope();
        }
    }
}
