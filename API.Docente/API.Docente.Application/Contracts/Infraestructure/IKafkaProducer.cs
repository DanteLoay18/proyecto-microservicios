
namespace API.Docentes.Application.Contracts.Infraestructure
{
    public interface IKafkaProducer
    {
        Task Produce(string topic, string key, string value);
    }
}
