using RabbitMqEx.Domain.Markers;

namespace RabbitMqEx.Domain.Dtos.RabbitMq;

public class FanOutExchangeConfigurationDto : IRabbitMqSetting
{

    public string ExchangeName { get; set; }
    public string QueueName { get; set; }
}