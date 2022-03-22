using System.Text;
using System.Text.Json;
using RabbitMqEx.Domain.Dtos.RabbitMq;
using RabbitMqEx.Domain.Markers;
using RabbitMqEx.Service.Common;
using ExchangeType = RabbitMQ.Client.ExchangeType;

namespace RabbitMqEx.Service.Publishers;

public class Publisher : BaseRabbitMq, IPublisher
{
    #region Fields

    #endregion
    #region Constructors
    public Publisher(RabbitMqConnectionStringDto configuration) : base(configuration)
    {
    }
    #endregion
    #region Methods
    public void PublishByDirectExchange<T>(T body, DirectExchangeConfigurationDto directExchangeConfiguration, QueueDeclareConfigurationDto? queueDeclareConfiguration = null, BasicPublishConfigurationDto? basicPublishConfiguration = null) where T : IRabbitMqObject
    {
        var (channel, connection) = CreateChannel();

        queueDeclareConfiguration ??= new QueueDeclareConfigurationDto();
        channel.QueueDeclare(directExchangeConfiguration.QueueName, queueDeclareConfiguration.Durable, queueDeclareConfiguration.Exclusive,
            queueDeclareConfiguration.AutoDelete, queueDeclareConfiguration.Arguments);

        var jsonModel = JsonSerializer.Serialize(body);
        var bodyBytes = Encoding.UTF8.GetBytes(jsonModel);
        var basicProperties = channel.CreateBasicProperties();
        var mandatory = false;
        if (basicPublishConfiguration is null)
        {
            basicProperties = null;
        }
        else
        {
            basicProperties.Persistent = basicPublishConfiguration.Persistent;
            mandatory = basicPublishConfiguration.Mandatory;
        }
        channel.BasicPublish(string.Empty, directExchangeConfiguration.QueueName, mandatory, basicProperties, bodyBytes);
        channel.Close();
        connection.Close();

    }

    public void PublishByFanOutExchange<T>(T body, FanOutExchangeConfigurationDto fanOutExchangeConfiguration, ExchangeDeclareConfigurationDto? exchangeDeclareConfiguration = null,
        BasicPublishConfigurationDto? basicPublishConfiguration = null) where T : IRabbitMqObject
    {
        var (channel, connection) = CreateChannel();
        exchangeDeclareConfiguration ??= new ExchangeDeclareConfigurationDto();

        channel.ExchangeDeclare(fanOutExchangeConfiguration.ExchangeName, ExchangeType.Fanout, exchangeDeclareConfiguration.Durable, exchangeDeclareConfiguration.AutoDelete, exchangeDeclareConfiguration.Arguments);

        var jsonModel = JsonSerializer.Serialize(body);
        var bodyBytes = Encoding.UTF8.GetBytes(jsonModel);
        var basicProperties = channel.CreateBasicProperties();
        var mandatory = false;
        if (basicPublishConfiguration is null)
        {
            basicProperties = null;
        }
        else
        {
            basicProperties.Persistent = basicPublishConfiguration.Persistent;
            mandatory = basicPublishConfiguration.Mandatory;
        }
        channel.BasicPublish(fanOutExchangeConfiguration.ExchangeName, string.Empty, mandatory, basicProperties, bodyBytes);
        channel.Close();
        connection.Close();
    }

    public void PublishByTopicExchange<T>(T body, TopicExchangeConfigurationDto topicExchangeConfiguration,
        ExchangeDeclareConfigurationDto? exchangeDeclareConfiguration = null,
        BasicPublishConfigurationDto? basicPublishConfiguration = null) where T : IRabbitMqObject
    {
        var (channel, connection) = CreateChannel();
        exchangeDeclareConfiguration ??= new ExchangeDeclareConfigurationDto();

        channel.ExchangeDeclare(topicExchangeConfiguration.ExchangeName, ExchangeType.Topic, exchangeDeclareConfiguration.Durable, exchangeDeclareConfiguration.AutoDelete, exchangeDeclareConfiguration.Arguments);

        var jsonModel = JsonSerializer.Serialize(body);
        var bodyBytes = Encoding.UTF8.GetBytes(jsonModel);
        var basicProperties = channel.CreateBasicProperties();
        var mandatory = false;
        if (basicPublishConfiguration is null)
        {
            basicProperties = null;
        }
        else
        {
            basicProperties.Persistent = basicPublishConfiguration.Persistent;
            mandatory = basicPublishConfiguration.Mandatory;
        }
        channel.BasicPublish(topicExchangeConfiguration.ExchangeName, topicExchangeConfiguration.PublisherRoutingKey, mandatory, basicProperties, bodyBytes);
        channel.Close();
        connection.Close();
    }

    public void PublishByHeadersExchange<T>(T body, HeadersExchangeConfigurationDto headersExchangeConfiguration,
        ExchangeDeclareConfigurationDto? exchangeDeclareConfiguration = null,
        BasicPublishConfigurationDto? basicPublishConfiguration = null) where T : IRabbitMqObject
    {
        var (channel, connection) = CreateChannel();
        exchangeDeclareConfiguration ??= new ExchangeDeclareConfigurationDto();
        basicPublishConfiguration ??= new BasicPublishConfigurationDto();

        channel.ExchangeDeclare(headersExchangeConfiguration.ExchangeName, ExchangeType.Topic, exchangeDeclareConfiguration.Durable, exchangeDeclareConfiguration.AutoDelete, exchangeDeclareConfiguration.Arguments);

        var jsonModel = JsonSerializer.Serialize(body);
        var bodyBytes = Encoding.UTF8.GetBytes(jsonModel);
        var basicProperties = channel.CreateBasicProperties();
        var mandatory = basicPublishConfiguration.Mandatory;
        basicProperties.Persistent = basicPublishConfiguration.Persistent;
        basicProperties.Headers = headersExchangeConfiguration.PublisherHeaders;

        channel.BasicPublish(headersExchangeConfiguration.ExchangeName, string.Empty, mandatory, basicProperties, bodyBytes);
        channel.Close();
        connection.Close();
    }

    #endregion




}