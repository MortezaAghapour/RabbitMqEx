using System.Text.Json;
using RabbitMQ.Client.Events;
using RabbitMqEx.Domain.Dtos.RabbitMq;
using RabbitMqEx.Domain.Markers;
using RabbitMqEx.Service.Common;

namespace RabbitMqEx.Service.Consumers;

public class Consumer : BaseRabbitMq, IConsumer
{
    #region Fields

    #endregion
    #region Constructors
    public Consumer(RabbitMqConnectionStringDto configuration) : base(configuration)
    {
    }
    #endregion
    #region Methods
    public T? DirectExchangeConsume<T>(DirectExchangeConfigurationDto directExchangeConfiguration, QueueDeclareConfigurationDto? queueDeclareConfiguration = null, BasicConsumeConfigurationDto? basicConsumeConfiguration = null, FairDispatchConfigurationDto? fairDispatchConfiguration = null) where T:IRabbitMqObject
    {
        var body = default(T);
        var (channel, connection) = CreateChannel();
        queueDeclareConfiguration ??= new QueueDeclareConfigurationDto();
        basicConsumeConfiguration ??= new BasicConsumeConfigurationDto();
        fairDispatchConfiguration ??= new FairDispatchConfigurationDto();
        channel.QueueDeclare(directExchangeConfiguration.QueueName, queueDeclareConfiguration.Durable, queueDeclareConfiguration.Exclusive,
            queueDeclareConfiguration.AutoDelete, queueDeclareConfiguration.Arguments);

        if (fairDispatchConfiguration.FairDispatchEnable)
        {
            channel.BasicQos(fairDispatchConfiguration.PrefetchSize, fairDispatchConfiguration.PrefetchCount, fairDispatchConfiguration.Global);
        }


        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (sender, eventArgs) =>
        {
            var bodyBytes = eventArgs.Body.ToArray();
             body = JsonSerializer.Deserialize<T>(bodyBytes);
            if (!basicConsumeConfiguration.AutoAck)
            {
                channel.BasicAck(eventArgs.DeliveryTag,true);
            }
        };
        channel.BasicConsume( directExchangeConfiguration.QueueName, basicConsumeConfiguration.AutoAck,basicConsumeConfiguration.ConsumerTag, basicConsumeConfiguration.NoLocal, queueDeclareConfiguration.Exclusive, queueDeclareConfiguration.Arguments, consumer);
        channel.Close();
        connection.Close();
        return body;
    }

    public T? FanOutExchangeConsume<T>(FanOutExchangeConfigurationDto fanOutExchangeConfiguration,
        QueueDeclareConfigurationDto? queueDeclareConfiguration = null,
        BasicConsumeConfigurationDto? basicConsumeConfiguration = null,
        FairDispatchConfigurationDto? fairDispatchConfiguration = null,
         QueueBindConfigurationDto? queueBindConfiguration = null) where T : IRabbitMqObject
    {
        var body = default(T);
        var (channel, connection) = CreateChannel();
        queueBindConfiguration ??= new QueueBindConfigurationDto();
        queueDeclareConfiguration ??= new QueueDeclareConfigurationDto();
        basicConsumeConfiguration ??= new BasicConsumeConfigurationDto();
        fairDispatchConfiguration ??= new FairDispatchConfigurationDto();
        channel.QueueDeclare(fanOutExchangeConfiguration.QueueName, queueDeclareConfiguration.Durable, queueDeclareConfiguration.Exclusive,
            queueDeclareConfiguration.AutoDelete, queueDeclareConfiguration.Arguments);

        channel.QueueBind(fanOutExchangeConfiguration.QueueName, fanOutExchangeConfiguration.ExchangeName,string.Empty, queueBindConfiguration.Arguments);

        if (fairDispatchConfiguration.FairDispatchEnable)
        {
            channel.BasicQos(fairDispatchConfiguration.PrefetchSize, fairDispatchConfiguration.PrefetchCount, fairDispatchConfiguration.Global);
        }


        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (sender, eventArgs) =>
        {
            var bodyBytes = eventArgs.Body.ToArray();
            body = JsonSerializer.Deserialize<T>(bodyBytes);
            if (!basicConsumeConfiguration.AutoAck)
            {
                channel.BasicAck(eventArgs.DeliveryTag, true);
            }
        };
        channel.BasicConsume(fanOutExchangeConfiguration.QueueName, basicConsumeConfiguration.AutoAck, basicConsumeConfiguration.ConsumerTag, basicConsumeConfiguration.NoLocal, queueDeclareConfiguration.Exclusive, queueDeclareConfiguration.Arguments, consumer);
        channel.Close();
        connection.Close();
        return body;
    }

    public T? TopicExchangeConsume<T>(TopicExchangeConfigurationDto topicExchangeConfiguration,
        QueueDeclareConfigurationDto? queueDeclareConfiguration = null,
        BasicConsumeConfigurationDto? basicConsumeConfiguration = null,
        FairDispatchConfigurationDto? fairDispatchConfiguration = null,
        QueueBindConfigurationDto? queueBindConfiguration = null) where T : IRabbitMqObject
    {
        var body = default(T);
        var (channel, connection) = CreateChannel();
        queueBindConfiguration ??= new QueueBindConfigurationDto();
        queueDeclareConfiguration ??= new QueueDeclareConfigurationDto();
        basicConsumeConfiguration ??= new BasicConsumeConfigurationDto();
        fairDispatchConfiguration ??= new FairDispatchConfigurationDto();
        channel.QueueDeclare(topicExchangeConfiguration.QueueName, queueDeclareConfiguration.Durable, queueDeclareConfiguration.Exclusive,
            queueDeclareConfiguration.AutoDelete, queueDeclareConfiguration.Arguments);

        channel.QueueBind(topicExchangeConfiguration.QueueName, topicExchangeConfiguration.ExchangeName, topicExchangeConfiguration.ConsumerRoutingKey, queueBindConfiguration.Arguments);

        if (fairDispatchConfiguration.FairDispatchEnable)
        {
            channel.BasicQos(fairDispatchConfiguration.PrefetchSize, fairDispatchConfiguration.PrefetchCount, fairDispatchConfiguration.Global);
        }


        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (sender, eventArgs) =>
        {
            var bodyBytes = eventArgs.Body.ToArray();
            body = JsonSerializer.Deserialize<T>(bodyBytes);
            if (!basicConsumeConfiguration.AutoAck)
            {
                channel.BasicAck(eventArgs.DeliveryTag, true);
            }
        };
        channel.BasicConsume(topicExchangeConfiguration.QueueName, basicConsumeConfiguration.AutoAck, basicConsumeConfiguration.ConsumerTag, basicConsumeConfiguration.NoLocal, queueDeclareConfiguration.Exclusive, queueDeclareConfiguration.Arguments, consumer);
        channel.Close();
        connection.Close();
        return body;
    }

    public T? HeadersExchangeConsume<T>(HeadersExchangeConfigurationDto headersExchangeConfiguration,
        QueueDeclareConfigurationDto? queueDeclareConfiguration = null,
        BasicConsumeConfigurationDto? basicConsumeConfiguration = null,
        FairDispatchConfigurationDto? fairDispatchConfiguration = null,
        QueueBindConfigurationDto? queueBindConfiguration = null) where T : IRabbitMqObject
    {
        var body = default(T);
        var (channel, connection) = CreateChannel();
        queueBindConfiguration ??= new QueueBindConfigurationDto();
        queueDeclareConfiguration ??= new QueueDeclareConfigurationDto();
        basicConsumeConfiguration ??= new BasicConsumeConfigurationDto();
        fairDispatchConfiguration ??= new FairDispatchConfigurationDto();
        channel.QueueDeclare(headersExchangeConfiguration.QueueName, queueDeclareConfiguration.Durable, queueDeclareConfiguration.Exclusive,
            queueDeclareConfiguration.AutoDelete, queueDeclareConfiguration.Arguments);

        channel.QueueBind(headersExchangeConfiguration.QueueName, headersExchangeConfiguration.ExchangeName, string.Empty, headersExchangeConfiguration.ConsumerHeaders);

        if (fairDispatchConfiguration.FairDispatchEnable)
        {
            channel.BasicQos(fairDispatchConfiguration.PrefetchSize, fairDispatchConfiguration.PrefetchCount, fairDispatchConfiguration.Global);
        }


        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (sender, eventArgs) =>
        {
            var bodyBytes = eventArgs.Body.ToArray();
            body = JsonSerializer.Deserialize<T>(bodyBytes);
            if (!basicConsumeConfiguration.AutoAck)
            {
                channel.BasicAck(eventArgs.DeliveryTag, true);
            }
        };
        channel.BasicConsume(headersExchangeConfiguration.QueueName, basicConsumeConfiguration.AutoAck, basicConsumeConfiguration.ConsumerTag, basicConsumeConfiguration.NoLocal, queueDeclareConfiguration.Exclusive, queueDeclareConfiguration.Arguments, consumer);
        channel.Close();
        connection.Close();
        return body;
    }

    #endregion



}