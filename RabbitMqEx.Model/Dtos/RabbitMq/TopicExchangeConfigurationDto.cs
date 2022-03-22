using RabbitMqEx.Domain.Markers;

namespace RabbitMqEx.Domain.Dtos.RabbitMq;

public class TopicExchangeConfigurationDto : IRabbitMqSetting
{

    public string ExchangeName { get; set; }
    public string QueueName { get; set; }
    public string PublisherRoutingKey { get; set; }
    public string ConsumerRoutingKey { get; set; }
}