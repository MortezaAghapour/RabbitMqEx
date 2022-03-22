using RabbitMqEx.Domain.Markers;

namespace RabbitMqEx.Domain.Dtos.RabbitMq;

public class HeadersExchangeConfigurationDto : IRabbitMqSetting
{
    public HeadersExchangeConfigurationDto()
    {
        PublisherHeaders = new Dictionary<string, object>();
        ConsumerHeaders = new Dictionary<string, object>();
    }
    public string ExchangeName { get; set; }
    public string QueueName { get; set; }
    public IDictionary<string, object> PublisherHeaders { get; set; }
    public IDictionary<string, object> ConsumerHeaders { get; set; }
}