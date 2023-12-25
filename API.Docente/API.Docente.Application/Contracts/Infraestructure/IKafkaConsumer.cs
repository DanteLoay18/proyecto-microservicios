

namespace API.Docentes.Application.Contracts.Infraestructure
{
    public interface IKafkaConsumer
    {
        void Consume(string topic, CancellationToken cancellationToken);
    }
}
