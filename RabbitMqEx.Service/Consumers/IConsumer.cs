using RabbitMqEx.Domain.Dtos.RabbitMq;
using RabbitMqEx.Domain.Markers;
using RabbitMqEx.Service.Common;

namespace RabbitMqEx.Service.Consumers;

public interface IConsumer:IBaseRabbitMq
{
    T? DirectExchangeConsume<T>(DirectExchangeConfigurationDto directExchangeConfiguration, QueueDeclareConfigurationDto? queueDeclareConfiguration = null, BasicConsumeConfigurationDto? basicConsumeConfiguration=null, FairDispatchConfigurationDto? fairDispatchConfiguration = null ) where T : IRabbitMqObject;
    T? FanOutExchangeConsume<T>(FanOutExchangeConfigurationDto fanOutExchangeConfiguration, QueueDeclareConfigurationDto? queueDeclareConfiguration = null, BasicConsumeConfigurationDto? basicConsumeConfiguration=null, FairDispatchConfigurationDto? fairDispatchConfiguration = null,QueueBindConfigurationDto? queueBindConfiguration=null ) where T : IRabbitMqObject;
    T? TopicExchangeConsume<T>(TopicExchangeConfigurationDto topicExchangeConfiguration, QueueDeclareConfigurationDto? queueDeclareConfiguration = null, BasicConsumeConfigurationDto? basicConsumeConfiguration=null, FairDispatchConfigurationDto? fairDispatchConfiguration = null,QueueBindConfigurationDto? queueBindConfiguration=null ) where T : IRabbitMqObject;
}