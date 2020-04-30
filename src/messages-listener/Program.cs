namespace EventPublisher
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MassTransit;
    using messages_contracts;

    public class Program
    {
        public static async Task Main()
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg => 
            {                
                var host = cfg.Host(new Uri("rabbitmq://rabbitmq-service/"), h => { });

                cfg.ReceiveEndpoint("my_queue", e => 
                {
                    e.Consumer<ValueConsumer>();
                });                
            });

            // Important! The bus must be started before using it!
            await busControl.StartAsync();

            Console.WriteLine("Listening messages. You can publish 'stop listening' if you wants stop this job.");

            while(Environment.GetEnvironmentVariable("EXIT") != "YES")
            {
                Thread.Sleep(5000);
            }

            await busControl.StopAsync();
        }
    }

    public class ValueConsumer :
    IConsumer<ValueEntered>
    {
        public async Task Consume(ConsumeContext<ValueEntered> context)
        {
            await Console.Out.WriteLineAsync($"Received: {context.Message.Value}");
            if(context.Message.Value == "stop listening")
                Environment.SetEnvironmentVariable("EXIT", "YES");
        }
    }
}