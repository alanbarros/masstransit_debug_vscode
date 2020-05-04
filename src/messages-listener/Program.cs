namespace EventPublisher
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MassTransit;
    using messages_contracts;

    public class Program
    {
        private static readonly AutoResetEvent autoResetEvent = new AutoResetEvent(false);

        public static async Task Main()
        {
            Console.WriteLine("Starting listener...");

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

            AppDomain.CurrentDomain.ProcessExit += async (o, e) =>
            {
                await busControl.StopAsync();
                Console.WriteLine("Terminating...");
                autoResetEvent.Set();
            };

            autoResetEvent.WaitOne();
        }
    }

    public class ValueConsumer : IConsumer<ValueEntered>
    {
        public async Task Consume(ConsumeContext<ValueEntered> context)
        {
            await Console.Out.WriteLineAsync($"Received: {context.Message.Value}");
            if(context.Message.Value == "stop listening")
                Environment.SetEnvironmentVariable("EXIT", "YES");
        }
    }
}