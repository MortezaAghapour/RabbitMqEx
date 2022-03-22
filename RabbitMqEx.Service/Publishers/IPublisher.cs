using RabbitMqEx.Domain.Dtos.RabbitMq;
using RabbitMqEx.Domain.Markers;
using RabbitMqEx.Service.Common;

namespace RabbitMqEx.Service.Publishers;

public interface IPublisher:IBaseRabbitMq
{
    void PublishByDirectExchange<T>(T body, DirectExchangeConfigurationDto directExchangeConfiguration, QueueDeclareConfigurationDto? queueDeclareConfiguration = null,BasicPublishConfigurationDto? basicPublishConfiguration = null) where T : IRabbitMqObject;
    void PublishByFanOutExchange<T>(T body, FanOutExchangeConfigurationDto fanOutExchangeConfiguration, ExchangeDeclareConfigurationDto? exchangeDeclareConfiguration = null, BasicPublishConfigurationDto? basicPublishConfiguration = null) where T : IRabbitMqObject;
    void PublishByTopicExchange<T>(T body, TopicExchangeConfigurationDto topicExchangeConfiguration, ExchangeDeclareConfigurationDto? exchangeDeclareConfiguration = null, BasicPublishConfigurationDto? basicPublishConfiguration = null) where T : IRabbitMqObject;


}