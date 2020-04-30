using System.Threading.Tasks;
using MassTransit;
using messages_contracts;
using messages_publisher.Application.Boudaries;

namespace messages_publisher.Infrastructure
{
    public class ValuePublisher : IValuePublisher
    {        
        private readonly IPublishEndpoint publishEndpoint;

        public ValuePublisher(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }

        public async Task PublishMessage(string message)
        {
            await publishEndpoint.Publish<ValueEntered>(new { Value = message });
        }
    }
}