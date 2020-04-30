using System.Threading.Tasks;

namespace messages_publisher.Application.Boudaries
{
    public interface IValuePublisher
    {
        Task PublishMessage(string message);
    }
}