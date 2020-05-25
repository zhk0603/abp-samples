using Volo.Abp.Autofac;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Modularity;
using Volo.Abp.RabbitMQ;

namespace App1
{
    [DependsOn(
        typeof(AbpEventBusRabbitMqModule),
        typeof(AbpAutofacModule)
        )]
    public class App1Module : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpRabbitMqOptions>(options =>
            {
                options.Connections.Default.UserName = "guest";
                options.Connections.Default.Password = "guest";
                options.Connections.Default.HostName = "192.168.1.11";
            });

            Configure<AbpRabbitMqEventBusOptions>(options =>
            {
                options.ClientName = "TestApp1";
                options.ExchangeName = "TestMessages";
            });
        }
    }
}